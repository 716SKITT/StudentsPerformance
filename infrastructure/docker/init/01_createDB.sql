-- Создание таблицы "Users" для хранения информации о пользователях
CREATE TABLE Users (
    UserID SERIAL PRIMARY KEY,
    Username VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash TEXT NOT NULL,
    Role VARCHAR(20) NOT NULL, -- 'Student', 'Professor', 'Admin'
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
ALTER TABLE Students ADD COLUMN UserID INT REFERENCES Users(UserID) ON DELETE SET NULL;
ALTER TABLE Professors ADD COLUMN UserID INT REFERENCES Users(UserID) ON DELETE SET NULL;

-- Создание таблицы "Students" для хранения информации о студентах
CREATE TABLE Students (
    StudentID SERIAL PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    Gender CHAR(1),
    Email VARCHAR(100) UNIQUE,
    PhoneNumber VARCHAR(20),
    Address VARCHAR(255),
    EnrollmentDate DATE NOT NULL
);

-- Создание таблицы "Courses" для хранения информации о курсах
CREATE TABLE Courses (
    CourseID SERIAL PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    CourseDescription TEXT,
    Credits INT NOT NULL
);

-- Создание таблицы "Professors" для хранения информации о преподавателях
CREATE TABLE Professors (
    ProfessorID SERIAL PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    PhoneNumber VARCHAR(20),
    Department VARCHAR(100)
);

-- Создание таблицы "Enrollments" для хранения информации о зачислениях студентов на курсы
CREATE TABLE Enrollments (
    EnrollmentID SERIAL PRIMARY KEY,
    StudentID INT REFERENCES Students(StudentID) ON DELETE CASCADE,
    CourseID INT REFERENCES Courses(CourseID) ON DELETE CASCADE,
    EnrollmentDate DATE NOT NULL
);

-- Создание таблицы "Assignments" для хранения информации о заданиях
CREATE TABLE Assignments (
    AssignmentID SERIAL PRIMARY KEY,
    CourseID INT REFERENCES Courses(CourseID) ON DELETE CASCADE,
    AssignmentName VARCHAR(100) NOT NULL,
    Description TEXT,
    DueDate DATE NOT NULL,
    MaxPoints INT NOT NULL
);

-- Создание таблицы "Grades" для хранения оценок студентов за задания
CREATE TABLE Grades (
    GradeID SERIAL PRIMARY KEY,
    EnrollmentID INT REFERENCES Enrollments(EnrollmentID) ON DELETE CASCADE,
    AssignmentID INT REFERENCES Assignments(AssignmentID) ON DELETE CASCADE,
    PointsEarned INT NOT NULL
);

-- Создание таблицы "Exams" для хранения информации о экзаменах
CREATE TABLE Exams (
    ExamID SERIAL PRIMARY KEY,
    CourseID INT REFERENCES Courses(CourseID) ON DELETE CASCADE,
    ExamName VARCHAR(100) NOT NULL,
    ExamDate DATE NOT NULL,
    MaxScore INT NOT NULL
);

-- Создание таблицы "ExamResults" для хранения результатов экзаменов
CREATE TABLE ExamResults (
    ExamResultID SERIAL PRIMARY KEY,
    EnrollmentID INT REFERENCES Enrollments(EnrollmentID) ON DELETE CASCADE,
    ExamID INT REFERENCES Exams(ExamID) ON DELETE CASCADE,
    Score INT NOT NULL
);

-- Создание таблицы "CourseProfessors" для связи курсов и преподавателей
CREATE TABLE CourseProfessors (
    CourseProfessorID SERIAL PRIMARY KEY,
    CourseID INT REFERENCES Courses(CourseID) ON DELETE CASCADE,
    ProfessorID INT REFERENCES Professors(ProfessorID) ON DELETE CASCADE
);

-- Создание таблицы "Attendance" для хранения информации о посещаемости
CREATE TABLE Attendance (
    AttendanceID SERIAL PRIMARY KEY,
    EnrollmentID INT REFERENCES Enrollments(EnrollmentID) ON DELETE CASCADE,
    AttendanceDate DATE NOT NULL,
    Status CHAR(1) CHECK (Status IN ('P', 'A')) -- P - Present, A - Absent
);

-- Создание таблицы "AcademicRecords" для хранения академических записей студентов
CREATE TABLE AcademicRecords (
    RecordID SERIAL PRIMARY KEY,
    StudentID INT REFERENCES Students(StudentID) ON DELETE CASCADE,
    GPA DECIMAL(3, 2) NOT NULL,
    AcademicYear INT NOT NULL,
    Semester INT NOT NULL
);

CREATE TABLE AuditLog (
    AuditID SERIAL PRIMARY KEY,
    TableName VARCHAR(100),
    OperationType VARCHAR(10),
    OperationTime TIMESTAMP,
    Username VARCHAR(100)
);