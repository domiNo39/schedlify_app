using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;
using Schedlify.Controllers;
using DateOnly = System.DateOnly;

namespace Schedlify.Scripts;

public class FillDb
{
    public static void Run()
    {
        UsersController usersController = new UsersController();
        User? usr = usersController.Register("admin@lnu.edu.ua", "securehash");

        ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
        
        UniversityRepository universityRepository = new UniversityRepository(_context);
        DepartmentRepository departmentRepository = new DepartmentRepository(_context);
        GroupRepository groupRepository = new GroupRepository(_context);
        ClassRepository classRepository = new ClassRepository(_context);
        AssignmentsRepository assignmentsRepository = new AssignmentsRepository(_context);

        universityRepository.Add("Львівська Національна Академія Мистецтв");
        universityRepository.Add("Український Католицький Університет");
        universityRepository.Add("Національний Університет Львівська Політехніка");
        University u = universityRepository.Add("Львівський Національний Університет ім. Іваана Франка");

        departmentRepository.Add(u.Id, "Біологічний факультет");
        departmentRepository.Add(u.Id, "Географічний факультет");
        departmentRepository.Add(u.Id, "Геологічний факультет");
        departmentRepository.Add(u.Id, "Економічний факультет");
        departmentRepository.Add(u.Id, "Факультет електроніки та комп’ютерних технологій");
        departmentRepository.Add(u.Id, "Факультет журналістики");
        departmentRepository.Add(u.Id, "Факультет іноземних мов");
        departmentRepository.Add(u.Id, "Історичний факультет");
        departmentRepository.Add(u.Id, "Факультет культури і мистецтв");
        departmentRepository.Add(u.Id, "Механіко-математичний факультет");
        departmentRepository.Add(u.Id, "Факультет міжнародних відносин");
        departmentRepository.Add(u.Id, "Факультет педагогічної освіти");
        departmentRepository.Add(u.Id, "Факультет управління фінансами та бізнесу");
        departmentRepository.Add(u.Id, "Фізичний факультет");
        departmentRepository.Add(u.Id, "Філософський факультет");
        departmentRepository.Add(u.Id, "Юридичний факультет");
        Department d = departmentRepository.Add(u.Id, "Факультет прикладної математики та інформатики");

        // Console.WriteLine(usr is not null);
        // return;
        groupRepository.Add(d.Id, usr.Id, "ПМІ-31с");
        groupRepository.Add(d.Id, usr.Id, "ПМІ-32с");
        groupRepository.Add(d.Id, usr.Id, "ПМІ-33с");
        groupRepository.Add(d.Id, usr.Id, "ПМК-31с");
        groupRepository.Add(d.Id, usr.Id, "ПМК-32с");
        groupRepository.Add(d.Id, usr.Id, "ПМІ-34с");
        groupRepository.Add(d.Id, usr.Id, "ПМІ-35с");
        groupRepository.Add(d.Id, usr.Id, "ПМІ-36с");
        groupRepository.Add(d.Id, usr.Id, "ПМО-31с");

        IEnumerable<Group> groups = groupRepository.GetByDepartmentId(d.Id);
        foreach (var group in groups)
        {
            Class cbd = classRepository.Add(group.Id, "Бази даних та інформаційні системи");
            Class ckm = classRepository.Add(group.Id, "Комп’ютерні інформаційні мережі");
            Class ckn = classRepository.Add(group.Id, "Обчислювальна геометрія і комп’ютерна графіка(КН)");
            Class cpro = classRepository.Add(group.Id, "Паралельні та розподілені обчислення");
            Class cpi = classRepository.Add(group.Id, "Програмна інженерія");
            Class cweb = classRepository.Add(group.Id, "Програмування та підтримка веб-застосувань");
            Class cjava = classRepository.Add(group.Id, "Програмування на Java");
            Class cunix = classRepository.Add(group.Id, "Програмування під UNIX-подібними системами");

            assignmentsRepository.AddAssignment(
                group.Id,
                cpi.Id,
                Weekday.Monday,
                new TimeOnly(15, 5),
                AssignmentType.Regular, 
                "Літинський С.В",
                "Університетська, 1", 
                "116", 
                null,
                null, null,
                new TimeOnly(16, 25)
            );
            assignmentsRepository.AddAssignment(
                group.Id,
                cweb.Id,
                Weekday.Monday,
                new TimeOnly(16, 40),
                AssignmentType.Regular,
                "Вовк О.В",
                "Університетська, 1", 
                "116",
                null, null, null,
                new TimeOnly(18, 00)
            );
            
            assignmentsRepository.AddAssignment(
                group.Id,
                ckn.Id,
                Weekday.Tuesday,
                new TimeOnly(13, 30),
                AssignmentType.Odd,
                "Златоус С.Д.",
                "Університетська, 1", 
                "119",
                null, null, null, 
                new TimeOnly(14, 50)
            );
            assignmentsRepository.AddAssignment(
                group.Id,
                ckm.Id,
                Weekday.Tuesday,
                new TimeOnly(15, 05),
                AssignmentType.Regular,
                "Жировецький В.В.",
                "Університетська, 1", 
                "118",
                null, null, null,
                new TimeOnly(16, 25)
            );

            assignmentsRepository.AddAssignment(
                group.Id,
                ckn.Id,
                Weekday.Thursday,
                new TimeOnly(15, 05),
                AssignmentType.Regular,
                "Венгерський П. С.",
                "Університетська, 1",
                "439",
                null, null, null,
                new TimeOnly(16, 25)
            );
            
            assignmentsRepository.AddAssignment(
                group.Id,
                cbd.Id,
                Weekday.Friday,
                new TimeOnly(8, 30),
                AssignmentType.Regular,
                "Яцик І.М",
                "Університетська, 1", 
                "119a",
                null, null, null,
                new TimeOnly(10, 10)
            );
            assignmentsRepository.AddAssignment(
                group.Id,
                cpro.Id,
                Weekday.Friday,
                new TimeOnly(10, 20),
                AssignmentType.Regular,
                "Яцик І.М",
                "Університетська, 1", 
                "119a",
                null, null, null,
                new TimeOnly(11, 30)
            );
            assignmentsRepository.AddAssignment(
                group.Id,
                cpro.Id,
                Weekday.Friday,
                new TimeOnly(10, 20),
                AssignmentType.Regular,
                "Гошко Б.М",
                "Університетська, 1", 
                "119a",
                null, null, null,
                new TimeOnly(11, 30)
            );
            assignmentsRepository.AddAssignment(
                group.Id,
                cpi.Id,
                Weekday.Friday,
                new TimeOnly(11, 50),
                AssignmentType.Regular,
                "Глова А.Р.",
                "Університетська, 1", 
                "119a",
                null, null, null,
                new TimeOnly(11, 30)
            );
            assignmentsRepository.AddAssignment(
                group.Id,
                cpro.Id,
                Weekday.Friday,
                new TimeOnly(13, 30),
                AssignmentType.Regular,
                "Гошко Б.М",
                "Університетська, 1",
                "118",
                null, null, null,
                new TimeOnly(14, 50)
            );
            
            assignmentsRepository.AddAssignment(
                group.Id,
                ckm.Id,
                Weekday.Wednesday,
                new TimeOnly(13, 30),
                AssignmentType.Special,
                "Літинський С.В",
                "Університетська, 1",
                "116", null, null,
                new DateOnly(2024, 11, 26), 
                new TimeOnly(14, 50)
            );
            assignmentsRepository.AddAssignment(
                group.Id,
                ckm.Id,
                Weekday.Wednesday,
                new TimeOnly(16, 40),
                AssignmentType.Special,
                "Жировецький В.В",
                "Університетська, 1",
                "118", null, null,
                new DateOnly(2024, 11, 27),
                new TimeOnly(18, 00)
            );
        }

        _context.SaveChanges();
    }
}