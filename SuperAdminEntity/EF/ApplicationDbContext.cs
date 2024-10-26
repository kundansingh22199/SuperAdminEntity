using Microsoft.EntityFrameworkCore;
using SuperAdminEntity.Models;

namespace SuperAdminEntity.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tbl_Master_Binary> Tbl_Master_Binary { get; set; }
        public DbSet<Tbl_Master_Direct> Tbl_Master_Direct { get; set; }
        public DbSet<Tbl_Master_Level> Tbl_Master_Level { get; set; }
        public DbSet<Tbl_Master_LevelOnRoi> Tbl_Master_LevelOnRoi { get; set; }
        public DbSet<Tbl_Master_Roi> Tbl_Master_Roi { get; set; }
        public DbSet<ControlMst> ControlMsts { get; set; }
        public DbSet<Tbl_DomainMaster> Tbl_DomainMaster { get; set; }
        public DbSet<Tbl_PackageMaster> Tbl_PackageMaster { get; set; }
        public DbSet<Tbl_UserPrefix> Tbl_UserPrefix { get; set; }
        public DbSet<ModChangePass> pass { get; set; }
        public DbSet<ChangePasswordResult> passres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //CreateStoredProcedures();
            modelBuilder.Entity<ModChangePass>()
           .HasNoKey()
           .ToView(null);
            modelBuilder.Entity<ChangePasswordResult>()
           .HasNoKey()
           .ToView(null);
            // modelBuilder.Entity<ModDomain>()
            //.HasNoKey()
            //.ToView(null);
        }
        public void CreateStoredProcedures()
        {
            string procLogin = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Proc_Login')
            BEGIN
            EXEC('
                CREATE procedure [dbo].[Proc_Login]  
                @username varchar(200),                  
                @Password nvarchar(200) 
                AS    
                BEGIN    
                    select username, password from ControlMst   where username=@username and password=@Password
                END
            ')
            END";
            string procAddDomain = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_AddDomain')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_AddDomain]     
                @Domain varchar(100),
                @Connection varchar(200)
                as      
                begin   
                    if not exists (select * from Tbl_DomainMaster where Domain=@Domain)  
                    Begin  
                        insert into Tbl_DomainMaster(Domain,createdate,Connection) values(@Domain,getdate(),@Connection)  
                    end 
                    else
                    begin
	                    update Tbl_DomainMaster set Connection=@Connection where Domain=@Domain
                    end
                end
            ')
            END";
            string procAddPack = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_AddPackage')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_AddPackage]  
                @Package decimal(18,2)  ,
                @Domain varchar(100)
                as  
                begin  
	                if not exists(select * from Tbl_PackageMaster where Package=@Package and Domain=@Domain)
	                Begin
		                insert into Tbl_PackageMaster(Package,createdate,Domain) values(@Package,getdate(),@Domain) 
	                End
                end
            ')
            END";
            string procDeletePack = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_DeletePackage')
            BEGIN
                EXEC('
                    CREATE PROCEDURE [dbo].[SP_DeletePackage]      
                    @Id INT,    
                    @action VARCHAR(20)    
                    AS      
                    BEGIN      
                        IF(@action = ''package'')    
                        BEGIN    
                            DELETE FROM Tbl_PackageMaster WHERE id = @Id     
                        END    
                        IF(@action = ''roi'')    
                        BEGIN    
                            DELETE FROM Tbl_Master_Roi WHERE id = @Id     
                        END    
                        IF(@action = ''binary'')    
                        BEGIN    
                            DELETE FROM Tbl_Master_Binary WHERE id = @Id     
                        END    
                        IF(@action = ''direct'')    
                        BEGIN    
                            DELETE FROM Tbl_Master_Direct WHERE id = @Id     
                        END    
                        IF(@action = ''level'')    
                        BEGIN    
                            DELETE FROM Tbl_Master_Level WHERE id = @Id     
                        END    
                        IF(@action = ''levelonroi'')    
                        BEGIN    
                            DELETE FROM Tbl_Master_LevelOnRoi WHERE id = @Id     
                        END    
                        IF(@action = ''domain'')    
                        BEGIN    
                            DELETE FROM Tbl_DomainMaster WHERE id = @Id     
                        END   
                        IF(@action = ''regprefix'')    
                        BEGIN    
                            DELETE FROM Tbl_UserPrefix WHERE id = @Id     
                        END   
                    END 
                ')
            END";
            string procGetCon = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_GetConnection')
            BEGIN
            EXEC('
                Create Proc [dbo].[SP_GetConnection]
                @domain varchar(100)
                as
                begin
	                select * from Tbl_DomainMaster where Domain=@domain
                end
            ')
            END";
            string procGetPack = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_GetPackage')
            BEGIN
                EXEC('
                    CREATE PROCEDURE [dbo].[SP_GetPackage]      
                    @Action VARCHAR(20)      
                    AS      
                    BEGIN      
                        IF(@Action = ''package'')      
                        BEGIN      
                            SELECT * FROM Tbl_PackageMaster      
                        END      
                        IF(@Action = ''roi'')      
                        BEGIN      
                            SELECT * FROM Tbl_Master_Roi      
                        END      
                        IF(@Action = ''direct'')      
                        BEGIN      
                            SELECT * FROM Tbl_Master_Direct      
                        END      
                        IF(@Action = ''binary'')      
                        BEGIN      
                            SELECT * FROM Tbl_Master_Binary      
                        END      
                        IF(@Action = ''level'')      
                        BEGIN      
                            SELECT * FROM Tbl_Master_Level ORDER BY Level_No      
                        END     
                        IF(@Action = ''levelonroi'')      
                        BEGIN      
                            SELECT * FROM Tbl_Master_LevelOnRoi ORDER BY Level_No      
                        END     
                        IF(@Action = ''domain'')      
                        BEGIN      
                            SELECT * FROM Tbl_DomainMaster      
                        END    
                        IF(@Action = ''gettable'')      
                        BEGIN      
                            SELECT TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME
                        END    
                        IF(@Action = ''regprefix'')      
                        BEGIN      
                            SELECT * FROM Tbl_UserPrefix      
                        END  
                        IF(@Action = ''getregno'')
                        BEGIN
                            SELECT TOP 1 * FROM appmst ORDER BY appmstid
                        END
                    END  
                ')
            END";
            string procMasterBinary = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_MasterBinary')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_MasterBinary]          
                @IncType varchar(20)='''',          
                @IncPer decimal(18,2)=0,          
                @IncFix decimal(18,2)=0,          
                --@IncPerId decimal(18,2)=0,          
                @IncCapping decimal(18,2)=0 ,        
                @Ratio varchar(20)=''''  ,      
                @CappingType varchar(100)='''',    
                @Package decimal(18,2)=0 ,
                @Domain varchar(100)
                AS          
                BEGIN          
                    if not exists(select * from Tbl_Master_Binary  where Package=@Package and Domain=@Domain)          
                    begin          
                        insert into Tbl_Master_Binary(Inc_type,Inc_per,Inc_fix,Inc_capping,Ratio,CappingType,Package,Domain)          
                        values(@IncType,@IncPer,@IncFix,@IncCapping,@Ratio,@CappingType,@Package,@Domain)          
                    end          
                    else          
                    begin          
                        update Tbl_Master_Binary set Inc_type=@IncType,Inc_per=@IncPer,Inc_fix=@IncFix,Inc_capping=@IncCapping ,Ratio=@Ratio,  
                        CappingType=@CappingType,Package=@Package,Domain=@Domain  where Package=@Package and Domain=@Domain        
                    end          
                END
            ')
            END";
            string procMasterDirect = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_MasterDirect')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_MasterDirect]      
                @IncType varchar(20)='''',      
                @IncPer decimal(18,2)=0,      
                @IncFix decimal(18,2)=0,      
                --@IncPerId decimal(18,2)=0,      
                @IncAllId int=0,      
                @IncAfterId int=0 ,     
                @Package decimal(18,2)=0,
                @Domain varchar(100)
                AS      
                BEGIN      
                    if not exists(select * from Tbl_Master_Direct where Package=@Package and Domain=@Domain)      
                    begin      
                        insert into Tbl_Master_Direct(Inc_type,Inc_per,Inc_fix,Inc_all_id,Inc_after_id,Package,Domain)      
                        values(@IncType,@IncPer,@IncFix,@IncAllId,@IncAfterId,@Package,@Domain)      
                    end      
                    else      
                    begin      
                        update Tbl_Master_Direct set Inc_type=@IncType,Inc_per=@IncPer,Inc_fix=@IncFix,Inc_all_id=@IncAllId,Inc_after_id=@IncAfterId,Package=@Package,
                        Domain=@Domain where Package=@Package and Domain=@Domain     
                    end      
                END 
            ')
            END";
            string procMasterLevel = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_MasterLevel')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_MasterLevel]    
                @IncType varchar(20)='''',    
                @IncPer decimal(18,2)=0,    
                @IncFix decimal(18,2)=0,    
                @LevelNo int=0,    
                @DirectId int=0,  
                @Domain varchar(100),
                @Package decimal(18,2)=0  
                AS    
                BEGIN    
                    if not exists(select * from Tbl_Master_Level where Level_No=@LevelNo and Domain=@Domain)    
                    begin    
                        insert into Tbl_Master_Level(Level_No,Inc_type,Level_per,Level_fix,Direct_id_require,Package,Domain)    
                        values(@LevelNo,@IncType,@IncPer,@IncFix,@DirectId,@Package,@Domain)    
                    end    
                    else    
                    begin    
                        update Tbl_Master_Level set Level_No=@LevelNo, Inc_type=@IncType,Level_per=@IncPer,Level_fix=@IncFix,    
                        Direct_id_require=@DirectId,Package=@Package,Domain=@Domain where Level_No=@LevelNo  and Domain=@Domain   
                    end    
                END
            ')
            END";
            string procMasterLevelOnROi = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_MasterLevelOnRoi')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_MasterLevelOnRoi]      
                @IncType varchar(20)='''',      
                @IncPer decimal(18,2)=0,      
                @IncFix decimal(18,2)=0,      
                @LevelNo int=0,      
                @DirectId int=0,    
                @Package decimal(18,2)=0 ,
                @Domain varchar(100)
                AS      
                BEGIN      
                    if not exists(select * from Tbl_Master_LevelOnRoi where Level_No=@LevelNo and Domain=@Domain)      
                    begin      
                        insert into Tbl_Master_LevelOnRoi(Level_No,Inc_type,Level_per,Level_fix,Direct_id_require,Package,Domain)      
                        values(@LevelNo,@IncType,@IncPer,@IncFix,@DirectId,@Package,@Domain)      
                    end      
                    else      
                    begin      
                        update Tbl_Master_LevelOnRoi set Level_No=@LevelNo, Inc_type=@IncType,Level_per=@IncPer,Level_fix=@IncFix,      
                        Direct_id_require=@DirectId,Package=@Package,Domain=@Domain where Level_No=@LevelNo and Domain=@Domain     
                    end      
                END
            ')
            END";
            string procMasterRoi = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_MasterRoi')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_MasterRoi]         
                @RoiType varchar(20)='''',        
                @RoiPer decimal(18,2)=0,        
                @RoiFix decimal(18,2)=0,        
                @RoiUpto decimal(18,2)=0,        
                @IncomeRecuring varchar(30)='''',        
                @MiniPer decimal(18,2)=0,        
                @MaxPer decimal(18,2)=0,        
                @RoiDay varchar(20)='''',        
                @SundayOff bit=0,        
                @SaturdaySundayOff bit=0,        
                @Random bit=0 ,    
                @Package decimal(18,2)=0 ,
                @Domain varchar(100)
                AS        
                BEGIN        
                    if (@Random=0)      
                    begin      
                        set @MiniPer=0      
                        set @MaxPer=0      
                    end      
                    if not exists(select * from Tbl_Master_Roi where Package=@Package and Domain=@Domain)        
                    begin        
                        insert into Tbl_Master_Roi(roi_type,roi_fix,roi_per,roi_upto,inc_recuring,RoiDay,sundayoff,sunday_saturday_off,random,min_per,max_per,Package,Domain)        
                        values(@RoiType,@RoiFix,@RoiPer,@RoiUpto,@IncomeRecuring,@RoiDay,@SundayOff,@SaturdaySundayOff,@Random,@MiniPer,@MaxPer,@Package,@Domain)        
                    end        
                    else        
                    begin        
                        update Tbl_Master_Roi set roi_type=@RoiType,roi_fix=@RoiFix,roi_per=@RoiPer,roi_upto=@RoiUpto,        
                        inc_recuring=@IncomeRecuring,RoiDay=@RoiDay,sundayoff=@SundayOff,sunday_saturday_off=@SaturdaySundayOff,        
                        random=@Random,min_per=@MiniPer,max_per=@MaxPer,Package=@Package,Domain=@Domain  where Package=@Package and Domain=@Domain       
                    end        
                END
            ')
            END";
            string procTruncateTable = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_TruncateTable')
            BEGIN
                EXEC('
                    CREATE PROCEDURE [dbo].[SP_TruncateTable]
                    @table VARCHAR(100)
                    AS
                    BEGIN
                        DECLARE @sql NVARCHAR(200);
                        SET @sql = ''TRUNCATE TABLE '' + QUOTENAME(@table);
                        EXEC sp_executesql @sql;
                    END
                ')
            END";
            string procUpdateAdminPass = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_UpdateAdminPassword')
            BEGIN
            EXEC('
                CREATE PROCEDURE [dbo].[SP_UpdateAdminPassword]
                @oldpassword VARCHAR(100),
                @newpassword VARCHAR(100),
                @confpassword VARCHAR(100)
                AS
                BEGIN
                    DECLARE @password VARCHAR(100), 
                            @result VARCHAR(200);
                    IF (@newpassword = @confpassword)
                    BEGIN
                        SELECT @password = Password FROM ControlMst;
                        IF (@oldpassword = @password)
                        BEGIN
                            UPDATE ControlMst
                            SET Password = @newpassword
                            WHERE Password = @oldpassword;
                            SET @result = ''Password updated successfully'';
                        END
                        ELSE
                        BEGIN
                            SET @result = ''Invalid Old Password'';
                        END
                    END
                    ELSE
                    BEGIN
                        SET @result = ''New Password and Confirm Password do not match'';
                    END
                    SELECT @result AS Message;
                END
            ')
            END";
            string procUserPrefix = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_UserPrefix')
            BEGIN
            EXEC('
                CREATE Proc [dbo].[SP_UserPrefix]
                @Domain varchar(100),
                @RegPrefix varchar(10),
                @TotalDigit int
                as
                begin
	                if not exists(select * from Tbl_UserPrefix where Domain=@Domain)
	                begin
		                insert into Tbl_UserPrefix(Domain,RegPrefix,TotalDigit) values(@Domain,@RegPrefix,@TotalDigit)
	                end
	                else
	                begin
		                update Tbl_UserPrefix set Domain=@Domain,RegPrefix=@RegPrefix,TotalDigit=@TotalDigit where Domain=@Domain
	                end
                end
            ')
            END";
            Database.ExecuteSqlRaw(procLogin);
            Database.ExecuteSqlRaw(procAddDomain);
            Database.ExecuteSqlRaw(procAddPack);
            Database.ExecuteSqlRaw(procDeletePack);
            Database.ExecuteSqlRaw(procGetCon);
            Database.ExecuteSqlRaw(procGetPack);
            Database.ExecuteSqlRaw(procMasterBinary);
            Database.ExecuteSqlRaw(procMasterDirect);
            Database.ExecuteSqlRaw(procMasterLevel);
            Database.ExecuteSqlRaw(procMasterLevelOnROi);
            Database.ExecuteSqlRaw(procMasterRoi);
            Database.ExecuteSqlRaw(procTruncateTable);
            Database.ExecuteSqlRaw(procUpdateAdminPass);
            Database.ExecuteSqlRaw(procUserPrefix);
        }
    }
}
