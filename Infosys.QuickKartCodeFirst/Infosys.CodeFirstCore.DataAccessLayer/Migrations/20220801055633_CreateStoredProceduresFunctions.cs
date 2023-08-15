using Microsoft.EntityFrameworkCore.Migrations;

namespace Infosys.CodeFirstCore.DataAccessLayer.Migrations
{
    public partial class CreateStoredProceduresFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
             migrationBuilder.AlterColumn<string>(
                 name: "ProductId",
                 table: "Products",
                 nullable: false,
                 oldClrType: typeof(string),
              oldType: "char(4)");
            

            //code to generate store Procedure, table valued function, scaler function
            var uspRegisterUser = @"CREATE PROCEDURE usp_RegisterUser
                           (
	                            @UserPassword VARCHAR(15),
	                            @Gender CHAR,
	                            @EmailId VARCHAR(50),
	                            @DateOfBirth DATE,
	                            @Address VARCHAR(200)
                           )
                           AS
                           BEGIN
	                            DECLARE @RoleId TINYINT
	                            BEGIN TRY
		                             IF (LEN(@EmailId)<4 OR LEN(@EmailId)>50 OR (@EmailId IS NULL))
			                              RETURN -1
		                             IF (LEN(@UserPassword)<8 OR LEN(@UserPassword)>15 OR (@UserPassword IS NULL))
			                              RETURN -2
		                             IF (@Gender<>'F' AND @Gender<>'M' OR (@Gender Is NULL))
			                              RETURN -3		
		                             IF (@DateOfBirth>=CAST(GETDATE() AS DATE) OR (@DateOfBirth IS NULL))
			                              RETURN -4
		                             IF DATEDIFF(d,@DateOfBirth,GETDATE())<6570
			                              RETURN -5
		                             IF (@Address IS NULL)
			                              RETURN -6
		                             SELECT @RoleId=RoleId FROM Role WHERE RoleName='Customer'
		                             INSERT INTO Users VALUES 
		                             (@EmailId,@UserPassword, @RoleId, @Gender, @DateOfBirth, @Address)
		                             RETURN 1
	                            END TRY
	                            BEGIN CATCH
		                             RETURN -99
	                            END CATCH
                          END
                          GO";
            migrationBuilder.Sql(uspRegisterUser);
            var ufnGetProductDetails = @"CREATE FUNCTION ufn_GetProductDetails(@CategoryId INT)
                                  RETURNS TABLE 
                                  AS
                                       RETURN (SELECT ProductId,ProductName,Price,CategoryId,QuantityAvailable FROM Products WHERE CategoryId=@CategoryId)
                                  GO";
            migrationBuilder.Sql(ufnGetProductDetails);

            var ufnGenerateNewProductId = @"CREATE FUNCTION ufn_GenerateNewProductId()
                                     RETURNS CHAR(4)
                                     AS
                                     BEGIN
	                                 DECLARE @ProductId CHAR(4)
	                                 IF NOT EXISTS(SELECT ProductId FROM Products)
		                                  SET @ProductId='P100'	
	                                 ELSE
		                                  SELECT @ProductId='P'+CAST(CAST(SUBSTRING(MAX(ProductId),2,3) AS INT)+1 AS CHAR) FROM Products
	                                 RETURN @ProductId
                                     END
                                     GO";
            migrationBuilder.Sql(ufnGenerateNewProductId);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
             migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Products",
                type: "char(4)",
                nullable: false,
                oldClrType: typeof(string));
            
        }
           
    }
}
