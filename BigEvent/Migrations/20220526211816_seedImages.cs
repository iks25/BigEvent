using Microsoft.EntityFrameworkCore.Migrations;

namespace BigEvent.Migrations
{
    public partial class seedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var mb = migrationBuilder;
            mb.Sql("INSERT INTO Images (Name,Src) Values ('default', '/imagesGallery/default.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('business', '/imagesGallery/business.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('football', '/imagesGallery/football.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('gig', '/imagesGallery/gig1.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('hackathon', '/imagesGallery/hackathon.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('lecture', '/imagesGallery/lecture.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('music', '/imagesGallery/music1.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('yoga', '/imagesGallery/yoga.jpg')");
            mb.Sql("INSERT INTO Images (Name,Src) Values ('billiards', '/imagesGallery/Billiards.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Images");


        }
    }
}
