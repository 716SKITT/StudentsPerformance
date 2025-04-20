INSERT INTO Students (FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, EnrollmentDate)
VALUES 
('Иван', 'Иванов', '1995-05-15', 'М', 'ivan.ivanov@example.com', '+79123456789', 'Москва, ул. Ленина, 1', '2020-09-01'),
('Мария', 'Петрова', '1996-08-22', 'Ж', 'maria.petrova@example.com', '+79234567890', 'Санкт-Петербург, ул. Невского, 10', '2020-09-01'),
('Алексей', 'Сидоров', '1997-03-10', 'М', 'alexey.sidorov@example.com', '+79345678901', 'Екатеринбург, ул. Кирова, 5', '2020-09-01');

INSERT INTO Courses (CourseName, CourseDescription, Credits)
VALUES 
('Математика', 'Основы высшей математики', 5),
('Физика', 'Основы физики', 4),
('Информатика', 'Основы программирования', 6);

INSERT INTO Professors (FirstName, LastName, Email, PhoneNumber, Department)
VALUES 
('Андрей', 'Смирнов', 'andrey.smirnov@example.com', '+79456789012', 'Математический факультет'),
('Елена', 'Кузнецова', 'elena.kuznetsova@example.com', '+79567890123', 'Физический факультет'),
('Дмитрий', 'Васильев', 'dmitry.vasilev@example.com', '+79678901234', 'Факультет информатики');

INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
VALUES 
(1, 1, '2020-09-01'),
(1, 2, '2020-09-01'),
(2, 1, '2020-09-01'),
(2, 3, '2020-09-01'),
(3, 2, '2020-09-01'),
(3, 3, '2020-09-01');

INSERT INTO Assignments (CourseID, AssignmentName, Description, DueDate, MaxPoints)
VALUES 
(1, 'Домашнее задание 1', 'Решение систем уравнений', '2020-10-01', 10),
(1, 'Домашнее задание 2', 'Интегрирование функций', '2020-11-01', 10),
(2, 'Лабораторная работа 1', 'Измерение физических величин', '2020-10-05', 15),
(2, 'Лабораторная работа 2', 'Изучение законов физики', '2020-11-05', 15),
(3, 'Программа 1', 'Написание программы на Python', '2020-10-10', 20),
(3, 'Программа 2', 'Разработка веб-приложения', '2020-11-10', 20);

INSERT INTO Grades (EnrollmentID, AssignmentID, PointsEarned)
VALUES 
(1, 1, 9),
(1, 2, 8),
(2, 3, 14),
(2, 4, 13),
(3, 5, 18),
(3, 6, 19);

INSERT INTO Exams (CourseID, ExamName, ExamDate, MaxScore)
VALUES 
(1, 'Экзамен по математике', '2020-12-20', 100),
(2, 'Экзамен по физике', '2020-12-22', 100),
(3, 'Экзамен по информатике', '2020-12-24', 100);

INSERT INTO ExamResults (EnrollmentID, ExamID, Score)
VALUES 
(1, 1, 85),
(2, 1, 90),
(3, 2, 78),
(4, 2, 88),
(5, 3, 92),
(6, 3, 87);

INSERT INTO CourseProfessors (CourseID, ProfessorID)
VALUES 
(1, 1),
(2, 2),
(3, 3);

INSERT INTO Attendance (EnrollmentID, AttendanceDate, Status)
VALUES 
(1, '2020-09-01', 'P'),
(1, '2020-09-02', 'P'),
(2, '2020-09-01', 'A'),
(2, '2020-09-02', 'P'),
(3, '2020-09-01', 'P'),
(3, '2020-09-02', 'P');

INSERT INTO AcademicRecords (StudentID, GPA, AcademicYear, Semester)
VALUES 
(1, 4.5, 2020, 1),
(2, 4.7, 2020, 1),
(3, 4.3, 2020, 1);

