using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPortal.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "TypeId", "Description", "Title" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque id nibh non mauris efficitur fringilla. Ut vitae nisi sed ipsum vestibulum vestibulum. Vestibulum nibh eros, varius eget nisl eu, scelerisque malesuada enim. Vivamus gravida lacus tortor, vitae rutrum nisl condimentum vel. Sed mollis justo vitae rhoncus feugiat. Cras faucibus, odio at dapibus maximus, lacus nunc vestibulum lectus, sit amet aliquet neque augue sed purus. Mauris lobortis finibus vulputate. Fusce pellentesque maximus tempus. Curabitur ullamcorper dictum enim, ut venenatis tellus sodales sit amet", "EventType 1" });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "TypeId", "Description", "Title" },
                values: new object[] { 2, "Curabitur ullamcorper odio at feugiat vulputate. Maecenas sed lacinia lectus, sed imperdiet ex. Mauris commodo sollicitudin lectus molestie tempus. Cras rutrum nisl purus, vitae cursus sem convallis rhoncus. In leo metus, molestie nec sagittis nec, congue eget felis. Pellentesque feugiat diam eu dolor pellentesque congue. Nunc tristique varius suscipit. Proin fringilla vehicula enim, eu placerat nunc iaculis ut. Nunc eu ligula et erat sagittis tincidunt quis laoreet sapien. Quisque scelerisque dolor et augue lobortis, nec pellentesque felis varius.", "EventType 2" });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "TypeId", "Description", "Title" },
                values: new object[] { 3, "Maecenas euismod consequat viverra. Duis et dignissim nisl, sodales cursus tortor. Proin pulvinar ante neque, sed aliquam neque lacinia a. Quisque ultrices convallis neque eu finibus. Integer libero ante, semper ut ante euismod, rhoncus imperdiet tortor. Mauris pretium scelerisque justo et pellentesque. Aliquam finibus ligula libero, eget tristique magna pulvinar sed", "EventType 3" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "EventTypeId", "Note", "Title" },
                values: new object[] { 1, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque id nibh non mauris efficitur fringilla. Ut vitae nisi sed ipsum vestibulum vestibulum. Vestibulum nibh eros, varius eget nisl eu, scelerisque malesuada enim. Vivamus gravida lacus tortor, vitae rutrum nisl condimentum vel. Sed mollis justo vitae rhoncus feugiat. Cras faucibus, odio at dapibus maximus, lacus nunc vestibulum lectus, sit amet aliquet neque augue sed purus. Mauris lobortis finibus vulputate. Fusce pellentesque maximus tempus. Curabitur ullamcorper dictum enim, ut venenatis tellus sodales sit amet", 1, "Proin molestie ligula nunc, et rutrum turpis porta et. Nulla purus quam, iaculis non quam vel, pellentesque tincidunt augue. Morbi accumsan ac sapien et tempor. Phasellus ex sem, faucibus posuere ultricies eu, aliquam a quam. Aenean convallis cursus ipsum, vel laoreet nisl blandit in. Curabitur condimentum velit et quam interdum, imperdiet pharetra orci consectetur. Cras tempor auctor tincidunt. Etiam id nulla sit amet diam posuere lobortis. Vestibulum vel urna a mauris elementum rutrum. Praesent venenatis maximus hendrerit. Pellentesque at lacus sit amet massa mattis iaculis sit amet sit amet nisi. Nulla consectetur elit vitae felis sodales, id bibendum odio convallis. Aenean aliquet, tortor non fermentum molestie, metus est tincidunt nibh, a faucibus arcu turpis in tortor. Ut molestie ullamcorper placerat", "Event 1" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "EventTypeId", "Note", "Title" },
                values: new object[] { 2, new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Curabitur ullamcorper odio at feugiat vulputate. Maecenas sed lacinia lectus, sed imperdiet ex. Mauris commodo sollicitudin lectus molestie tempus. Cras rutrum nisl purus, vitae cursus sem convallis rhoncus. In leo metus, molestie nec sagittis nec, congue eget felis. Pellentesque feugiat diam eu dolor pellentesque congue. Nunc tristique varius suscipit. Proin fringilla vehicula enim, eu placerat nunc iaculis ut. Nunc eu ligula et erat sagittis tincidunt quis laoreet sapien. Quisque scelerisque dolor et augue lobortis, nec pellentesque felis varius.", 2, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec rutrum non sapien ut fermentum. Mauris in velit tellus. Praesent sodales ipsum quis turpis porttitor, non efficitur tortor consectetur. Integer iaculis tempor purus. Sed eget eros sed dui faucibus feugiat eget ut nibh. In luctus velit libero, eget sagittis eros condimentum non. Suspendisse potenti. Vivamus gravida fringilla ornare. Duis pellentesque nec ante vehicula pharetra. Morbi ac neque in risus laoreet ullamcorper. Fusce facilisis ullamcorper eros non molestie. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos", "Event 2" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "EventTypeId", "Note", "Title" },
                values: new object[] { 3, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maecenas euismod consequat viverra. Duis et dignissim nisl, sodales cursus tortor. Proin pulvinar ante neque, sed aliquam neque lacinia a. Quisque ultrices convallis neque eu finibus. Integer libero ante, semper ut ante euismod, rhoncus imperdiet tortor. Mauris pretium scelerisque justo et pellentesque. Aliquam finibus ligula libero, eget tristique magna pulvinar sed", 3, "Suspendisse ultricies euismod elit egestas tempor. Sed lobortis neque felis, id egestas nibh dictum a. Phasellus molestie risus sed sem maximus tempus. Fusce sit amet lorem a neque suscipit luctus eget ut mauris. Morbi ac ex orci. Nulla diam risus, ullamcorper eu sapien vel, pretium imperdiet ipsum. Vestibulum ac vehicula mauris, quis maximus nibh. Curabitur ut mauris sapien. Vestibulum pretium scelerisque elit, mollis commodo nibh accumsan eu. Vestibulum at elit nunc. Aliquam eu tortor orci. Nullam venenatis, sapien vel lobortis consectetur, ante nibh egestas augue, non hendrerit felis diam ut metus.", "Event 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
