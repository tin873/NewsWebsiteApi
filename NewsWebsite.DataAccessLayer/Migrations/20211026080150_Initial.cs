using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebsite.DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");
            //GET ALL
            var getAllPosts = @"CREATE PROCEDURE SP_GETALLPost
                               AS
                               BEGIN
                                    select * from Post
                               END";

            migrationBuilder.Sql(getAllPosts);
            var getAllCategories = @"CREATE PROCEDURE SP_GETALLCategory
                               AS
                               BEGIN
                                    select * from Category
                               END";

            migrationBuilder.Sql(getAllCategories);
            //GET BY ID
            var getPostById = @"CREATE PROCEDURE SP_GETPostBYID(@PostId int)
                               AS
                               BEGIN
                                    select * from Post Where PostId = @PostId
                               END";

            migrationBuilder.Sql(getPostById);
            var getCategoryById = @"CREATE PROCEDURE SP_GETCategoryBYID(@CategoryId int)
                               AS
                               BEGIN
                                    select * from Category Where CategoryId = @CategoryId
                               END";

            migrationBuilder.Sql(getCategoryById);
            //Get Post By CategoryId
            var getPostByCategoryId = @"CREATE PROCEDURE SP_GETPOSTBYCATEGORYID(@CategoryId int)
                                    AS
                                    BEGIN
                                        select * from Post Where CategoryId = @CategoryId
                                    END";

            migrationBuilder.Sql(getPostByCategoryId);
            //Get Post search
            var getPostSearch = @"CREATE PROCEDURE SP_GETPOSTSEARCH(@Search nvarchar(100))
                                    AS
                                    BEGIN
                                        select * from Post Where Title LIKE '%'+@Search+'%'
                                    END";

            migrationBuilder.Sql(getPostSearch);
            //ADD new
            var addPost = @"CREATE PROCEDURE SP_ADDPost(@Title nvarchar(50), @Image ntext, @Content ntext, @Status bit, @CategoryId int, @CreateDate DateTime=null, @CreateBy nvarchar(100)=null, @ModifiedDate DateTime=null, @ModifiedBy nvarchar(100)=null)
                                        AS
                                        BEGIN
	                                         INSERT INTO Post VALUES(@Title, @Image, @Content, @Status, @CategoryId, @CreateDate, @CreateBy, @ModifiedDate, @ModifiedBy)
                                        END";

            migrationBuilder.Sql(addPost);
            var addCategory = @"CREATE PROCEDURE SP_ADDCategory(@CategoryName nvarchar(50), @Description ntext=null, @CreateDate DateTime=null, @CreateBy nvarchar(100)=null, @ModifiedDate DateTime=null, @ModifiedBy nvarchar(100)=null)
                                AS
                                BEGIN
                                   Declare @Count int
                                   select @Count=COUNT(*) from Category where CategoryName = @CategoryName
                                   if(@Count = 0)
	                                   INSERT INTO Category VALUES(@CategoryName, @Description, @CreateDate, @CreateBy, @ModifiedDate, @ModifiedBy)
                                   else
                                       Print 'Danh muc da ton tai'
                               END";
            migrationBuilder.Sql(addCategory);
            //Update
            var updateCategory = @"CREATE PROCEDURE SP_UPDATECATEGORY(@CategoryId int,@CategoryName nvarchar(50), @Description ntext=null, @CreateDate DateTime=null, @CreateBy nvarchar(100)=null, @ModifiedDate DateTime=null, @ModifiedBy nvarchar(100)=null)
                                   AS
                                   BEGIN
                                      Declare @Count int
                                      select @Count=COUNT(*) from Category where CategoryId = @CategoryId
                                      if(@Count > 0)
                                         UPDATE Category
                                         SET CategoryName = @CategoryName, Description = @Description, CreatedDate = @CreateDate, CreatedBy = @CreateBy, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate
                                         WHERE CategoryId = @CategoryId;
                                      else
                                         Print 'Khong co danh muc can sua'
                                   END";
            migrationBuilder.Sql(updateCategory);
            var updatePost = @"CREATE PROCEDURE SP_UPDATEPOST(@PostId int, @Title nvarchar(50), @Image ntext, @Content ntext, @Status bit, @CategoryId int, @CreateDate DateTime=null, @CreateBy nvarchar(100)=null, @ModifiedDate DateTime=null, @ModifiedBy nvarchar(100)=null)
                               AS
                               BEGIN
                                   Declare @Count int
                                   select @Count=COUNT(*) from Post where PostId = @PostId
                                   if(@Count > 0)
                                       UPDATE Post
                                       SET Title = @Title, Image = @Image, Content = @Content, Status = @Status, CategoryId = @CategoryId, CreatedDate = @CreateDate, CreatedBy = @CreateBy, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate
                                       WHERE PostId = @PostId;
                                   else
                                       Print 'Khong co bai viet can sua'
                               END";
            migrationBuilder.Sql(updatePost);
            //Delete
            var deleteCategory = @"CREATE PROCEDURE SP_DELETECategory(@CatgoryId int)
                                   AS
                                   BEGIN
                                       Declare @Count int
                                       select @Count=COUNT(*) from Category where CategoryId = @CatgoryId
                                       if(@Count > 0)
                                           DELETE Category
                                           WHERE CategoryId = @CatgoryId;
                                       else
                                           Print 'Khong co danh muc de xoa'
                                   END";
            migrationBuilder.Sql(deleteCategory);
            var deletePost = @"CREATE PROCEDURE SP_DELETEPost(@PostId int)
                               AS
                               BEGIN
                                   Declare @Count int
                                   select @Count=COUNT(*) from Post where PostId = @PostId
                                   if(@Count > 0)
                                       DELETE Post
                                       WHERE PostId = @PostId;
                                   else
                                       Print 'Khong co bai viet de xoa'
                                   END";
            migrationBuilder.Sql(deletePost);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
