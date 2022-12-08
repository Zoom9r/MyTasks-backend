﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace MyTasksDataBase.Migrations
{
    [DbContext(typeof(MyTasksDBContext))]
    partial class MyTasksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyTasksDataBase.Models.ListOfTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListOfTasksModels");
                });

            modelBuilder.Entity("MyTasksDataBase.Models.StatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ListOfTasksId")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListOfTasksId");

                    b.ToTable("StatusModels");
                });

            modelBuilder.Entity("MyTasksDataBase.Models.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListOfTasksId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListOfTasksId");

                    b.HasIndex("StatusId");

                    b.ToTable("MyTasks");
                });

            modelBuilder.Entity("MyTasksDataBase.Models.StatusModel", b =>
                {
                    b.HasOne("MyTasksDataBase.Models.ListOfTasks", null)
                        .WithMany("Statuses")
                        .HasForeignKey("ListOfTasksId");
                });

            modelBuilder.Entity("MyTasksDataBase.Models.TaskModel", b =>
                {
                    b.HasOne("MyTasksDataBase.Models.ListOfTasks", "ListOfTasks")
                        .WithMany("Tasks")
                        .HasForeignKey("ListOfTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyTasksDataBase.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListOfTasks");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MyTasksDataBase.Models.ListOfTasks", b =>
                {
                    b.Navigation("Statuses");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
