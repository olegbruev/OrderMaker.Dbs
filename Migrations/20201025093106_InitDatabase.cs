using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mtd.OrderMaker.Dbs.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mtd_category_form",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    parent = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_category_form", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mtd_config_file",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    file_size = table.Column<long>(type: "bigint", nullable: false),
                    file_type = table.Column<string>(type: "varchar(45)", nullable: false),
                    file_data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_config_file", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mtd_config_param",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(45)", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_config_param", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mtd_group",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mtd_sys_style",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_sys_style", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mtd_sys_term",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    sign = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_sys_term", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mtd_sys_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_sys_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mtd_form",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    mtd_category = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sequence = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'"),
                    visible_number = table.Column<bool>(type: "bit", nullable: false),
                    visible_date = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_form", x => x.id);
                    table.ForeignKey(
                        name: "fk_form_grooup",
                        column: x => x.mtd_category,
                        principalTable: "mtd_category_form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_approval",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    mtd_form = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_approval", x => x.id);
                    table.ForeignKey(
                        name: "fk_approvel_form",
                        column: x => x.mtd_form,
                        principalTable: "mtd_form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_filter",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_form = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    page_size = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'10'"),
                    searchText = table.Column<string>(type: "varchar(256)", nullable: false),
                    searchNumber = table.Column<string>(type: "varchar(45)", nullable: false),
                    page = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    waitlist = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'"),
                    show_number = table.Column<bool>(type: "bit", nullable: false),
                    show_date = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_filter", x => x.id);
                    table.ForeignKey(
                        name: "mtd_filter_mtd_form",
                        column: x => x.mtd_form,
                        principalTable: "mtd_form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_form_desk",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image = table.Column<byte[]>(type: "image", nullable: false),
                    image_type = table.Column<string>(type: "varchar(256)", nullable: false),
                    image_size = table.Column<int>(type: "int", nullable: false),
                    color_font = table.Column<string>(type: "varchar(45)", nullable: false, defaultValueSql: "'white'"),
                    color_back = table.Column<string>(type: "varchar(45)", nullable: false, defaultValueSql: "'gray'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_form_desk", x => x.id);
                    table.ForeignKey(
                        name: "fk_mtd_form_des_mtd_from",
                        column: x => x.id,
                        principalTable: "mtd_form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_form_header",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image = table.Column<byte[]>(type: "image", nullable: false),
                    image_type = table.Column<string>(type: "varchar(256)", nullable: false),
                    image_size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_form_header", x => x.id);
                    table.ForeignKey(
                        name: "fk_image_form",
                        column: x => x.id,
                        principalTable: "mtd_form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_form_part",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    sequence = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'"),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    mtd_sys_style = table.Column<int>(type: "int", nullable: false),
                    mtd_form = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<bool>(type: "bit", nullable: false),
                    child = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_form_part", x => x.id);
                    table.ForeignKey(
                        name: "fk_mtd_form_part_mtd_form1",
                        column: x => x.mtd_form,
                        principalTable: "mtd_form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mtd_form_part_mtd_sys_style1",
                        column: x => x.mtd_sys_style,
                        principalTable: "mtd_sys_style",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_store",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sequence = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'"),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    mtd_form = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    timecr = table.Column<DateTime>(type: "datetime", nullable: false),
                    ParentNavigationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store", x => x.id);
                    table.ForeignKey(
                        name: "fk_mtd_store_mtd_form1",
                        column: x => x.mtd_form,
                        principalTable: "mtd_form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mtd_store_mtd_store_ParentNavigationId",
                        column: x => x.ParentNavigationId,
                        principalTable: "mtd_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mtd_approval_stage",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    mtd_approval = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stage = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    block_parts = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_approval_stage", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_approval",
                        column: x => x.mtd_approval,
                        principalTable: "mtd_approval",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_filter_date",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date_start = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_end = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_filter_date", x => x.id);
                    table.ForeignKey(
                        name: "fk_date_filter",
                        column: x => x.id,
                        principalTable: "mtd_filter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_filter_script",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_filter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(256)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    script = table.Column<string>(type: "text", nullable: false),
                    apply = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_filter_script", x => x.id);
                    table.ForeignKey(
                        name: "fk_script_filter",
                        column: x => x.mtd_filter,
                        principalTable: "mtd_filter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_form_part_field",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(120)", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", nullable: false),
                    required = table.Column<bool>(type: "bit", nullable: false),
                    sequence = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'"),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    mtd_sys_type = table.Column<int>(type: "int", nullable: false),
                    mtd_form_part = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_form_part_field", x => x.id);
                    table.ForeignKey(
                        name: "fk_mtd_form_part_field_mtd_form_part1",
                        column: x => x.mtd_form_part,
                        principalTable: "mtd_form_part",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mtd_form_part_field_mtd_sys_type1",
                        column: x => x.mtd_sys_type,
                        principalTable: "mtd_sys_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_form_part_header",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image = table.Column<byte[]>(type: "image", nullable: false),
                    image_type = table.Column<string>(type: "varchar(256)", nullable: false),
                    image_size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_form_part_header", x => x.id);
                    table.ForeignKey(
                        name: "fk_image_form_part",
                        column: x => x.id,
                        principalTable: "mtd_form_part",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_log_document",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mtd_store = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_name = table.Column<string>(type: "varchar(256)", nullable: false),
                    timech = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_log_document", x => x.id);
                    table.ForeignKey(
                        name: "fk_log_document_store",
                        column: x => x.mtd_store,
                        principalTable: "mtd_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_owner",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_name = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_owner", x => x.id);
                    table.ForeignKey(
                        name: "fk_owner_store",
                        column: x => x.id,
                        principalTable: "mtd_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_log_approval",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mtd_store = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    result = table.Column<int>(type: "int", nullable: false),
                    timecr = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_log_approval", x => x.id);
                    table.ForeignKey(
                        name: "fk_log_approval_store",
                        column: x => x.mtd_store,
                        principalTable: "mtd_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_log_approval_stage",
                        column: x => x.stage,
                        principalTable: "mtd_approval_stage",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_approval",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    md_approve_stage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parts_approved = table.Column<string>(type: "text", nullable: false),
                    complete = table.Column<bool>(type: "bit", nullable: false),
                    result = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_approval", x => x.id);
                    table.ForeignKey(
                        name: "fk_store_approve",
                        column: x => x.id,
                        principalTable: "mtd_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_store_approve_stage",
                        column: x => x.md_approve_stage,
                        principalTable: "mtd_approval_stage",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mtd_filter_column",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_filter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_form_part_field = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sequence = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_filter_column", x => x.id);
                    table.ForeignKey(
                        name: "mtd_filter_column_mtd_field",
                        column: x => x.mtd_filter,
                        principalTable: "mtd_filter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "mtd_roster_field",
                        column: x => x.mtd_form_part_field,
                        principalTable: "mtd_form_part_field",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mtd_filter_field",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_filter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_form_part_field = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<string>(type: "varchar(256)", nullable: false),
                    mtd_term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_filter_field", x => x.id);
                    table.ForeignKey(
                        name: "mtd_filter_field_mtd_field",
                        column: x => x.mtd_filter,
                        principalTable: "mtd_filter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "mtd_filter_field_mtd_form_field",
                        column: x => x.mtd_form_part_field,
                        principalTable: "mtd_form_part_field",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "mtd_filter_field_mtd_term",
                        column: x => x.mtd_term,
                        principalTable: "mtd_sys_term",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_form_list",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_form = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_form_list", x => x.id);
                    table.ForeignKey(
                        name: "fk_list_field",
                        column: x => x.id,
                        principalTable: "mtd_form_part_field",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_list_form",
                        column: x => x.mtd_form,
                        principalTable: "mtd_form",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_stack",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mtd_store = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mtd_form_part_field = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_stack", x => x.id);
                    table.ForeignKey(
                        name: "fk_mtd_store_stack_mtd_form_part_field1",
                        column: x => x.mtd_form_part_field,
                        principalTable: "mtd_form_part_field",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mtd_store_stack_mtd_store",
                        column: x => x.mtd_store,
                        principalTable: "mtd_store",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_link",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    mtd_store = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Register = table.Column<string>(type: "varchar(768)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_link", x => x.id);
                    table.ForeignKey(
                        name: "fk_mtd_store_link_mtd_store_stack",
                        column: x => x.id,
                        principalTable: "mtd_store_stack",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mtd_store_link_mtd_store1",
                        column: x => x.mtd_store,
                        principalTable: "mtd_store",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_stack_date",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    register = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_stack_date", x => x.id);
                    table.ForeignKey(
                        name: "fk_date_stack",
                        column: x => x.id,
                        principalTable: "mtd_store_stack",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_stack_decimal",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    register = table.Column<decimal>(type: "decimal(20,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_stack_decimal", x => x.id);
                    table.ForeignKey(
                        name: "fk_decimal_stack",
                        column: x => x.id,
                        principalTable: "mtd_store_stack",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_stack_file",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    register = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    file_name = table.Column<string>(type: "varchar(256)", nullable: false),
                    file_size = table.Column<int>(type: "int", nullable: false),
                    file_type = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_stack_file", x => x.id);
                    table.ForeignKey(
                        name: "fk_file_stack",
                        column: x => x.id,
                        principalTable: "mtd_store_stack",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_stack_int",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    register = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_stack_int", x => x.id);
                    table.ForeignKey(
                        name: "fk_int_stack",
                        column: x => x.id,
                        principalTable: "mtd_store_stack",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mtd_store_stack_text",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    register = table.Column<string>(type: "varchar(768)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtd_store_stack_text", x => x.id);
                    table.ForeignKey(
                        name: "fk_text_stack",
                        column: x => x.id,
                        principalTable: "mtd_store_stack",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_approval",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_approvel_form_idx",
                table: "mtd_approval",
                column: "mtd_form");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_approval_stage",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_stage_approval_idx",
                table: "mtd_approval_stage",
                column: "mtd_approval");

            migrationBuilder.CreateIndex(
                name: "IX_USER",
                table: "mtd_approval_stage",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_category_form",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_group_themself_idx",
                table: "mtd_category_form",
                column: "parent");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_config_file",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_config_param",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_filter",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "mtd_filter_mtd_form_idx",
                table: "mtd_filter",
                column: "mtd_form");

            migrationBuilder.CreateIndex(
                name: "IX_INDEX_USER",
                table: "mtd_filter",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_filter_column",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "mtd_filter_column_idx",
                table: "mtd_filter_column",
                column: "mtd_filter");

            migrationBuilder.CreateIndex(
                name: "mtd_roster_field_idx",
                table: "mtd_filter_column",
                column: "mtd_form_part_field");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_filter_date",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_filter_field",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "mtd_filter_idx",
                table: "mtd_filter_field",
                column: "mtd_filter");

            migrationBuilder.CreateIndex(
                name: "mtd_filter_field_mtd_form_field_idx",
                table: "mtd_filter_field",
                column: "mtd_form_part_field");

            migrationBuilder.CreateIndex(
                name: "mtd_filter_field_term_idx",
                table: "mtd_filter_field",
                column: "mtd_term");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_filter_script",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_script_filter_idx",
                table: "mtd_filter_script",
                column: "mtd_filter");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_form",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_form_grooup_idx",
                table: "mtd_form",
                column: "mtd_category");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_form_desk",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_form_header",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_form_list",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_list_form_idx",
                table: "mtd_form_list",
                column: "mtd_form");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_form_part",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_mtd_form_part_mtd_form1_idx",
                table: "mtd_form_part",
                column: "mtd_form");

            migrationBuilder.CreateIndex(
                name: "fk_mtd_form_part_mtd_sys_style1_idx",
                table: "mtd_form_part",
                column: "mtd_sys_style");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_form_part_field",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_mtd_form_part_field_mtd_form_part1_idx",
                table: "mtd_form_part_field",
                column: "mtd_form_part");

            migrationBuilder.CreateIndex(
                name: "fk_mtd_form_part_field_mtd_sys_type1_idx",
                table: "mtd_form_part_field",
                column: "mtd_sys_type");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_form_part_header",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_group",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_log_approval",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_log_approval_store_idx",
                table: "mtd_log_approval",
                column: "mtd_store");

            migrationBuilder.CreateIndex(
                name: "fk_log_approval_stage_idx",
                table: "mtd_log_approval",
                column: "stage");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_log_document",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_log_document_store_idx",
                table: "mtd_log_document",
                column: "mtd_store");

            migrationBuilder.CreateIndex(
                name: "ix_date",
                table: "mtd_log_document",
                column: "timech");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_mtd_store_mtd_form1_idx",
                table: "mtd_store",
                column: "mtd_form");

            migrationBuilder.CreateIndex(
                name: "IX_mtd_store_ParentNavigationId",
                table: "mtd_store",
                column: "ParentNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_TIMECR",
                table: "mtd_store",
                column: "timecr");

            migrationBuilder.CreateIndex(
                name: "Seq_Unique",
                table: "mtd_store",
                columns: new[] { "mtd_form", "sequence" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_APPROVED",
                table: "mtd_store_approval",
                column: "complete");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_approval",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_store_approve_stage_idx",
                table: "mtd_store_approval",
                column: "md_approve_stage");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_link",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_mtd_store_link_mtd_store1_idx",
                table: "mtd_store_link",
                column: "mtd_store");

            migrationBuilder.CreateIndex(
                name: "ix_unique",
                table: "mtd_store_link",
                columns: new[] { "mtd_store", "id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_owner",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER",
                table: "mtd_store_owner",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_stack",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_mtd_store_stack_mtd_form_part_field1_idx",
                table: "mtd_store_stack",
                column: "mtd_form_part_field");

            migrationBuilder.CreateIndex(
                name: "fk_mtd_store_stack_mtd_store_idx",
                table: "mtd_store_stack",
                column: "mtd_store");

            migrationBuilder.CreateIndex(
                name: "IX_UNIQUE",
                table: "mtd_store_stack",
                columns: new[] { "mtd_store", "mtd_form_part_field" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_stack_date",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DATESTACK",
                table: "mtd_store_stack_date",
                column: "register");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_stack_decimal",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DECIMALREGISTER",
                table: "mtd_store_stack_decimal",
                column: "register");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_stack_file",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_store_stack_int",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INTSTACK",
                table: "mtd_store_stack_int",
                column: "register");

            migrationBuilder.CreateIndex(
                name: "category_id_UNIQUE",
                table: "mtd_store_stack_text",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REGISTER_TEXT",
                table: "mtd_store_stack_text",
                column: "register");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_sys_style",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_sys_term",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "mtd_sys_type",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mtd_config_file");

            migrationBuilder.DropTable(
                name: "mtd_config_param");

            migrationBuilder.DropTable(
                name: "mtd_filter_column");

            migrationBuilder.DropTable(
                name: "mtd_filter_date");

            migrationBuilder.DropTable(
                name: "mtd_filter_field");

            migrationBuilder.DropTable(
                name: "mtd_filter_script");

            migrationBuilder.DropTable(
                name: "mtd_form_desk");

            migrationBuilder.DropTable(
                name: "mtd_form_header");

            migrationBuilder.DropTable(
                name: "mtd_form_list");

            migrationBuilder.DropTable(
                name: "mtd_form_part_header");

            migrationBuilder.DropTable(
                name: "mtd_group");

            migrationBuilder.DropTable(
                name: "mtd_log_approval");

            migrationBuilder.DropTable(
                name: "mtd_log_document");

            migrationBuilder.DropTable(
                name: "mtd_store_approval");

            migrationBuilder.DropTable(
                name: "mtd_store_link");

            migrationBuilder.DropTable(
                name: "mtd_store_owner");

            migrationBuilder.DropTable(
                name: "mtd_store_stack_date");

            migrationBuilder.DropTable(
                name: "mtd_store_stack_decimal");

            migrationBuilder.DropTable(
                name: "mtd_store_stack_file");

            migrationBuilder.DropTable(
                name: "mtd_store_stack_int");

            migrationBuilder.DropTable(
                name: "mtd_store_stack_text");

            migrationBuilder.DropTable(
                name: "mtd_sys_term");

            migrationBuilder.DropTable(
                name: "mtd_filter");

            migrationBuilder.DropTable(
                name: "mtd_approval_stage");

            migrationBuilder.DropTable(
                name: "mtd_store_stack");

            migrationBuilder.DropTable(
                name: "mtd_approval");

            migrationBuilder.DropTable(
                name: "mtd_form_part_field");

            migrationBuilder.DropTable(
                name: "mtd_store");

            migrationBuilder.DropTable(
                name: "mtd_form_part");

            migrationBuilder.DropTable(
                name: "mtd_sys_type");

            migrationBuilder.DropTable(
                name: "mtd_form");

            migrationBuilder.DropTable(
                name: "mtd_sys_style");

            migrationBuilder.DropTable(
                name: "mtd_category_form");
        }
    }
}
