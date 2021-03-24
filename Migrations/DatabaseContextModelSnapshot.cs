// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schulcast.Server.Data;

namespace Schulcast.Server.Migrations {
	[DbContext (typeof (DatabaseContext))]
	partial class DatabaseContextModelSnapshot : ModelSnapshot {
		protected override void BuildModel (ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation ("ProductVersion", "3.1.1");

			modelBuilder.Entity ("Schulcast.Server.Models.File", b => {
				b.Property<int> ("Id")
					.ValueGeneratedOnAdd ()
					.HasColumnType ("INTEGER");

				b.Property<string> ("Path")
					.HasColumnType ("TEXT");

				b.HasKey ("Id");

				b.ToTable ("Files");
			});

			modelBuilder.Entity ("Schulcast.Server.Models.Member", b => {
				b.Property<int> ("Id")
					.ValueGeneratedOnAdd ()
					.HasColumnType ("INTEGER");

				b.Property<int> ("ImageId")
					.HasColumnType ("INTEGER");

				b.Property<string> ("Nickname")
					.IsRequired ()
					.HasColumnType ("TEXT")
					.HasMaxLength (50);

				b.Property<string> ("Password")
					.HasColumnType ("TEXT")
					.HasMaxLength (64);

				b.Property<string> ("Role")
					.HasColumnType ("TEXT")
					.HasMaxLength (50);

				b.HasKey ("Id");

				b.ToTable ("Members");
			});

			modelBuilder.Entity ("Schulcast.Server.Models.MemberData", b => {
				b.Property<int> ("Id")
					.ValueGeneratedOnAdd ()
					.HasColumnType ("INTEGER");

				b.Property<int> ("MemberId")
					.HasColumnType ("INTEGER");

				b.Property<string> ("Response")
					.IsRequired ()
					.HasColumnType ("TEXT");

				b.Property<string> ("Title")
					.IsRequired ()
					.HasColumnType ("TEXT")
					.HasMaxLength (100);

				b.HasKey ("Id");

				b.HasIndex ("MemberId");

				b.ToTable ("MemberData");
			});

			modelBuilder.Entity ("Schulcast.Server.Models.MemberTask", b => {
				b.Property<int> ("MemberId")
					.HasColumnType ("INTEGER");

				b.Property<int> ("TaskId")
					.HasColumnType ("INTEGER");

				b.HasKey ("MemberId", "TaskId");

				b.HasIndex ("TaskId");

				b.ToTable ("MemberTask");
			});

			modelBuilder.Entity ("Schulcast.Server.Models.Post", b => {
				b.Property<int> ("Id")
					.ValueGeneratedOnAdd ()
					.HasColumnType ("INTEGER");

				b.Property<string> ("Content")
					.IsRequired ()
					.HasColumnType ("TEXT");

				b.Property<DateTime> ("LastUpdated")
					.HasColumnType ("TEXT");

				b.Property<int> ("MemberId")
					.HasColumnType ("INTEGER");

				b.Property<DateTime> ("Published")
					.HasColumnType ("TEXT");

				b.Property<string> ("Title")
					.IsRequired ()
					.HasColumnType ("TEXT")
					.HasMaxLength (100);

				b.HasKey ("Id");

				b.HasIndex ("MemberId");

				b.ToTable ("Posts");
			});

			modelBuilder.Entity ("Schulcast.Server.Models.Slide", b => {
				b.Property<int> ("Id")
					.ValueGeneratedOnAdd ()
					.HasColumnType ("INTEGER");

				b.Property<string> ("Description")
					.IsRequired ()
					.HasColumnType ("TEXT")
					.HasMaxLength (200);

				b.Property<int> ("ImageId")
					.HasColumnType ("INTEGER");

				b.HasKey ("Id");

				b.ToTable ("Slides");
			});

			modelBuilder.Entity ("Schulcast.Server.Models.Task", b => {
				b.Property<int> ("Id")
					.ValueGeneratedOnAdd ()
					.HasColumnType ("INTEGER");

				b.Property<string> ("Title")
					.IsRequired ()
					.HasColumnType ("TEXT")
					.HasMaxLength (50);

				b.HasKey ("Id");

				b.ToTable ("Tasks");
			});

			modelBuilder.Entity ("Schulcast.Server.Models.MemberData", b => {
				b.HasOne ("Schulcast.Server.Models.Member", "Member")
					.WithMany ("Data")
					.HasForeignKey ("MemberId")
					.OnDelete (DeleteBehavior.Cascade)
					.IsRequired ();
			});

			modelBuilder.Entity ("Schulcast.Server.Models.MemberTask", b => {
				b.HasOne ("Schulcast.Server.Models.Member", "Member")
					.WithMany ("Tasks")
					.HasForeignKey ("MemberId")
					.OnDelete (DeleteBehavior.Cascade)
					.IsRequired ();

				b.HasOne ("Schulcast.Server.Models.Task", "Task")
					.WithMany ("Members")
					.HasForeignKey ("TaskId")
					.OnDelete (DeleteBehavior.Cascade)
					.IsRequired ();
			});

			modelBuilder.Entity ("Schulcast.Server.Models.Post", b => {
				b.HasOne ("Schulcast.Server.Models.Member", "Member")
					.WithMany ("Posts")
					.HasForeignKey ("MemberId")
					.OnDelete (DeleteBehavior.Cascade)
					.IsRequired ();
			});
#pragma warning restore 612, 618
		}
	}
}