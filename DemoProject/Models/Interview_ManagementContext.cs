using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoProject.Models
{
    public partial class Interview_ManagementContext : DbContext
    {
        public Interview_ManagementContext()
        {
        }

        public Interview_ManagementContext(DbContextOptions<Interview_ManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Benefit> Benefits { get; set; } = null!;
        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Level> Levels { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=HERNIEL;user=Herniel;password=Sanyuri1805;database=Interview_Management");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.ToTable("benefit");

                entity.Property(e => e.BenefitId).HasColumnName("benefit_id");

                entity.Property(e => e.BenefitName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("benefit_name");

                entity.HasMany(d => d.Jobs)
                    .WithMany(p => p.Benefits)
                    .UsingEntity<Dictionary<string, object>>(
                        "JobBenefit",
                        l => l.HasOne<Job>().WithMany().HasForeignKey("JobId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKbreqdqw5ps6hd3rsdris4qcs3"),
                        r => r.HasOne<Benefit>().WithMany().HasForeignKey("BenefitId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKrwgx5uvlt0roso4vuukvtbwmk"),
                        j =>
                        {
                            j.HasKey("BenefitId", "JobId").HasName("PK__job_bene__F262CE6202C195C7");

                            j.ToTable("job_benefit");

                            j.IndexerProperty<long>("BenefitId").HasColumnName("benefit_id");

                            j.IndexerProperty<long>("JobId").HasColumnName("job_id");
                        });
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__candidat__46A222CDF4A7D9DD");

                entity.ToTable("candidate");

                entity.HasIndex(e => e.Email, "UK_qfut8ruekode092nlkipgl09g")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedOn)
                    .HasPrecision(6)
                    .HasColumnName("created_on");

                entity.Property(e => e.CvAttachment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cv_attachment");

                entity.Property(e => e.Dob)
                    .HasPrecision(6)
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ExpYear)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("exp_year");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HighestLevel).HasColumnName("highest_level");

                entity.Property(e => e.IsActivated).HasColumnName("is_activated");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.RecruiterId).HasColumnName("recruiter_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.HighestLevelNavigation)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.HighestLevel)
                    .HasConstraintName("FKnku9r5fsgi6o5alru11yinrvn");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FKawqc3qqhshpoi0t6r79c2hlaq");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.RecruiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKgln1o7stjijeovh3yl9xmuu4v");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK3hx30sj4mddv5d24mgbppnmj5");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK4sn940s55wnxxa7k1bmjjy00w");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Candidates)
                    .UsingEntity<Dictionary<string, object>>(
                        "CandidateSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKb7cxhiqhcah7c20a2cdlvr1f8"),
                        r => r.HasOne<Candidate>().WithMany().HasForeignKey("CandidateId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKijjf42p0sh2c2na28g5aalx2p"),
                        j =>
                        {
                            j.HasKey("CandidateId", "SkillId").HasName("PK__candidat__B606E42F05B17DCA");

                            j.ToTable("candidate_skill");

                            j.IndexerProperty<long>("CandidateId").HasColumnName("candidate_id");

                            j.IndexerProperty<long>("SkillId").HasColumnName("skill_id");
                        });
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.ContractName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contract_name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("job");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasPrecision(6)
                    .HasColumnName("end_date");

                entity.Property(e => e.IsActivated).HasColumnName("is_activated");

                entity.Property(e => e.JobName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_name");

                entity.Property(e => e.SalaryMax).HasColumnName("salary_max");

                entity.Property(e => e.SalaryMin).HasColumnName("salary_min");

                entity.Property(e => e.StartDate)
                    .HasPrecision(6)
                    .HasColumnName("start_date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.WorkingAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("working_address");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FKtpro3k2axsnrs8ilpt8nmmf27");

                entity.HasMany(d => d.Levels)
                    .WithMany(p => p.Jobs)
                    .UsingEntity<Dictionary<string, object>>(
                        "JobLevel",
                        l => l.HasOne<Level>().WithMany().HasForeignKey("LevelId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKj53h8iylbhjv71e1d4574d6cl"),
                        r => r.HasOne<Job>().WithMany().HasForeignKey("JobId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK8bsd5e1hj57ycm9hlw0f9i2rl"),
                        j =>
                        {
                            j.HasKey("JobId", "LevelId").HasName("PK__job_leve__4E06D7C12E8C0586");

                            j.ToTable("job_level");

                            j.IndexerProperty<long>("JobId").HasColumnName("job_id");

                            j.IndexerProperty<long>("LevelId").HasColumnName("level_id");
                        });

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Jobs)
                    .UsingEntity<Dictionary<string, object>>(
                        "JobSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKj33qbbf3vk1lvhqpcosnh54u1"),
                        r => r.HasOne<Job>().WithMany().HasForeignKey("JobId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK9ix4wg520ii2gu2felxdhdup6"),
                        j =>
                        {
                            j.HasKey("JobId", "SkillId").HasName("PK__job_skil__E1891E92044E0203");

                            j.ToTable("job_skill");

                            j.IndexerProperty<long>("JobId").HasColumnName("job_id");

                            j.IndexerProperty<long>("SkillId").HasColumnName("skill_id");
                        });
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("level");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.LevelName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("level_name");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("offer");

                entity.HasIndex(e => e.ScheduleId, "UK_aybgh1no4wf2rsv7bh9opdxue")
                    .IsUnique()
                    .HasFilter("([schedule_id] IS NOT NULL)");

                entity.Property(e => e.OfferId).HasColumnName("offer_id");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                entity.Property(e => e.ContractFrom)
                    .HasPrecision(6)
                    .HasColumnName("contract_from");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.ContractTo)
                    .HasPrecision(6)
                    .HasColumnName("contract_to");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DueDate)
                    .HasPrecision(6)
                    .HasColumnName("due_date");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.Slary).HasColumnName("slary");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK9irqkqj4ujilh16d896pwf5e1");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FKslueps8n40qg8t0vk96v4f6my");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FKch0ncduorncootji1225bck8n");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK8srb9fme7ck0m6pdxx5iylwb2");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FKhfc0sau1x1q86eo0sg7ptrvg3");

                entity.HasOne(d => d.Schedule)
                    .WithOne(p => p.Offer)
                    .HasForeignKey<Offer>(d => d.ScheduleId)
                    .HasConstraintName("FK1n9c3wr4xkdanjahw3velwhhq");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK8cbl7gv0ljy4tk7wpaxnbdc9b");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("position_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.HasIndex(e => new { e.CandidateId, e.ScheduleTime }, "UKn7t6qj77ulsabasy0p3lm1skx")
                    .IsUnique()
                    .HasFilter("([candidate_id] IS NOT NULL AND [schedule_time] IS NOT NULL)");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.MeetingUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("meeting_url");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Result)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("result");

                entity.Property(e => e.ScheduleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("schedule_name");

                entity.Property(e => e.ScheduleTime)
                    .HasPrecision(6)
                    .HasColumnName("schedule_time");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FKbcubtcqap9gvy06ps8mgxyprf");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK7srsrfnh5xwdowc31fgultubk");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FKxuyi3n8wkvyluloud2ncx8n2");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("skill_name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__user__46A222CD6702A02E");

                entity.ToTable("user");

                entity.HasIndex(e => e.UserName, "UK_lqjrcobrh9jc8wpcar64q1bfh")
                    .IsUnique()
                    .HasFilter("([user_name] IS NOT NULL)");

                entity.HasIndex(e => e.Email, "UK_ob8kqyqqgmefl0aco34akdtpe")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Dob)
                    .HasPrecision(6)
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ExpiredDate)
                    .HasPrecision(6)
                    .HasColumnName("expired_date");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsActivated).HasColumnName("is_activated");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FKehjs1gva5qvv8lwqv4f8ko14l");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FKdl9dqp078pc03g6kdnxmnlqpc");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FKevogonfyjcbymv9u2fd1fhri9");

                entity.HasMany(d => d.Offers)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserOffer",
                        l => l.HasOne<Offer>().WithMany().HasForeignKey("OfferId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKmt2pabwbpocwljm1hn3vjq3kj"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK429n3ifeatdhlhsoixad63bkr"),
                        j =>
                        {
                            j.HasKey("AccountId", "OfferId").HasName("PK__user_off__769F15618E4F3098");

                            j.ToTable("user_offer");

                            j.IndexerProperty<long>("AccountId").HasColumnName("account_id");

                            j.IndexerProperty<long>("OfferId").HasColumnName("offer_id");
                        });

                entity.HasMany(d => d.Schedules)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserSchedule",
                        l => l.HasOne<Schedule>().WithMany().HasForeignKey("ScheduleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKdd4cwg959bmy4551iiivx4wdw"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKr8ouvjko7p6m9w4h16cg3jaf"),
                        j =>
                        {
                            j.HasKey("AccountId", "ScheduleId").HasName("PK__user_sch__AAE48A6B9C7D5C22");

                            j.ToTable("user_schedule");

                            j.IndexerProperty<long>("AccountId").HasColumnName("account_id");

                            j.IndexerProperty<long>("ScheduleId").HasColumnName("schedule_id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
