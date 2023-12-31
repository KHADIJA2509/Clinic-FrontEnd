CREATE DATABASE ClinicLDatabasee;
USE ClinicLDatabasee;

-- Create the OWNER TABLE
CREATE TABLE OWNER (
    OwnerID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    Gender VARCHAR(6),
    BirthDate DATE,
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    Address VARCHAR(100),
    About VARCHAR(300),
    Age INT
);

DELIMITER //
CREATE TRIGGER calc_owner_age
BEFORE INSERT ON OWNER
FOR EACH ROW
SET NEW.Age = YEAR(CURDATE()) - YEAR(NEW.BirthDate);
//
DELIMITER ;

-- Create the DOCTOR table
CREATE TABLE DOCTOR (
    DoctorID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    Gender VARCHAR(6),
    BirthDate DATE,
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    Address VARCHAR(100),
    About VARCHAR(300),
    Age INT
);

DELIMITER //
CREATE TRIGGER calc_doctor_age
BEFORE INSERT ON DOCTOR
FOR EACH ROW
SET NEW.Age = YEAR(CURDATE()) - YEAR(NEW.BirthDate);
//
DELIMITER ;

-- Create the RECEPTION table
CREATE TABLE RECEPTION (
    ReceptionID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    Gender VARCHAR(6),
    BirthDate DATE,
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    Address VARCHAR(100),
    About VARCHAR(300),
    Age INT
);

DELIMITER //
CREATE TRIGGER calc_reception_age
BEFORE INSERT ON RECEPTION
FOR EACH ROW
SET NEW.Age = YEAR(CURDATE()) - YEAR(NEW.BirthDate);
//
DELIMITER ;

-- Create the PATIENT table
CREATE TABLE PATIENT (
    PatientID INT PRIMARY KEY AUTO_INCREMENT,
    PatientNAID INT,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    PatientType VARCHAR(100),
    OtherContact VARCHAR(20),
    PhoneNumber VARCHAR(20),
    BirthDate DATE,
    Address VARCHAR(100),
    Age INT
);

DELIMITER //
CREATE TRIGGER calc_patient_age
BEFORE INSERT ON PATIENT
FOR EACH ROW
SET NEW.Age = YEAR(CURDATE()) - YEAR(NEW.BirthDate);
//
DELIMITER ;

CREATE TABLE LOGIN (
    DoctorID INT,
    ReceptionID INT,
    OwnerID INT,
    Username VARCHAR(255),
    UNIQUE KEY unique_username (Username(255)),
    Password VARCHAR(15),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID),
    FOREIGN KEY (ReceptionID) REFERENCES RECEPTION(ReceptionID),
    FOREIGN KEY (OwnerID) REFERENCES OWNER(OwnerID)
);

CREATE TABLE REPORT (
    ReportID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT,
    DoctorID INT,
    Title VARCHAR(300),
    Description VARCHAR(300),
    ReportDateAndTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    SessionNumber INT,
    Diagnosis VARCHAR(300),
    TreatmentStage VARCHAR(100),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID),
    FOREIGN KEY (PatientID) REFERENCES PATIENT(PatientID)
);

CREATE TABLE CAMERA (
    CameraID INT PRIMARY KEY AUTO_INCREMENT,
    Brand VARCHAR(100),
    Model VARCHAR(100),
    ViewDateAndTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ViewDescription VARCHAR(300)
);

CREATE TABLE ATTENDANCE (
    AttendanceID INT PRIMARY KEY AUTO_INCREMENT,
    OwnerID INT,
    DoctorID INT,
    ReceptionID INT,
    TimeofArrival TIME,
    TimeofLeave TIME,
    DateofTheDay DATE,
    Absence VARCHAR(300),
    Excuse VARCHAR(300),
    TotalHoursWorking INT,
    FOREIGN KEY (OwnerID) REFERENCES OWNER(OwnerID),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID),
    FOREIGN KEY (ReceptionID) REFERENCES RECEPTION(ReceptionID)
);

CREATE TABLE APPOINTMENTS (
    AppointmentID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    BirthDate DATE,
    Gender VARCHAR(6),
    DoctorID INT,
    AppointmentDate DATE,
    AppointmentTime TIME,
    Address VARCHAR(100),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    ReferralDoctor VARCHAR(300),
    ClinicReferralDoctorID INT,
    Insurance VARCHAR(300),
    StateOfPatient VARCHAR(100),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID)
);

CREATE TABLE ASSESSMENT (
    AssessmentID INT PRIMARY KEY AUTO_INCREMENT,
    PatientAge INT,
    PatientComplaint VARCHAR(300),
    BodyPart VARCHAR(100),
    InjuryType VARCHAR(100),
    TreatmentPlan VARCHAR(300)
);

CREATE TABLE MEDICAL_HISTORY (
    PatientID INT PRIMARY KEY,
    Surgeries VARCHAR(255),
    Illness VARCHAR(255),
    FamilyMedicalBackground VARCHAR(100)
);

CREATE TABLE PATIENT_DATA (
    PatientName VARCHAR(255),
    PatientID INT,
    AssessmentID INT,
    ReportID INT,
    PRIMARY KEY (PatientName),
    FOREIGN KEY (PatientID) REFERENCES PATIENT(PatientID)
);


-- RELATIONS

CREATE TABLE CHECK_TIMES (
    AppointmentID INT,
    DoctorID INT,
    FOREIGN KEY (AppointmentID) REFERENCES APPOINTMENTS(AppointmentID),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID)
);

CREATE TABLE RECORD_INFO (
    PatientID INT,
    ReceptionID INT,
    FOREIGN KEY (PatientID) REFERENCES PATIENT(PatientID),
    FOREIGN KEY (ReceptionID) REFERENCES RECEPTION(ReceptionID)
);

CREATE TABLE HAVE (
    PatientID INT,
    PatientName VARCHAR(255),
    FOREIGN KEY (PatientID) REFERENCES PATIENT(PatientID),
    FOREIGN KEY (PatientName) REFERENCES PATIENT_DATA(PatientName)
);

CREATE TABLE VIEW_CAMERA (
    CameraID INT,
    OwnerID INT,
    ReceptionID INT,
    FOREIGN KEY (CameraID) REFERENCES CAMERA(CameraID),
    FOREIGN KEY (OwnerID) REFERENCES OWNER(OwnerID),
    FOREIGN KEY (ReceptionID) REFERENCES RECEPTION(ReceptionID)
);

CREATE TABLE ADD_DOCTOR (
    OwnerID INT,
    DoctorID INT,
    FOREIGN KEY (OwnerID) REFERENCES OWNER(OwnerID),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID)
);

CREATE TABLE RECORD_ATTENDANCE (
    AttendanceID INT,
    DoctorID INT,
    OwnerID INT,
    ReceptionID INT,
    FOREIGN KEY (AttendanceID) REFERENCES ATTENDANCE(AttendanceID),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID),
    FOREIGN KEY (OwnerID) REFERENCES OWNER(OwnerID),
    FOREIGN KEY (ReceptionID) REFERENCES RECEPTION(ReceptionID)
);

CREATE TABLE VIEW_ATTENDANCE (
    OwnerID INT,
    AttendanceID INT,
    FOREIGN KEY (OwnerID) REFERENCES OWNER(OwnerID),
    FOREIGN KEY (AttendanceID) REFERENCES ATTENDANCE(AttendanceID)
);

CREATE TABLE VIEW_PATIENT_DATA (
    DoctorID INT,
    PatientName VARCHAR(255),
    FOREIGN KEY (DoctorID) REFERENCES DOCTOR(DoctorID),
    FOREIGN KEY (PatientName) REFERENCES PATIENT_DATA(PatientName)
);

-- Insert Sample Data

-- Sample data for OWNER table
INSERT INTO OWNER (FirstName, LastName, Gender, BirthDate, Email, PhoneNumber, Address, About)
VALUES ('John', 'Doe', 'Male', '1990-01-01', 'john.doe@email.com', '1234567890', '123 Main St', 'About John');

-- Sample data for DOCTOR table
INSERT INTO DOCTOR (FirstName, LastName, Gender, BirthDate, Email, PhoneNumber, Address, About)
VALUES ('Dr. Jane', 'Smith', 'Female', '1985-05-15', 'jane.smith@email.com', '9876543210', '456 Oak St', 'About Dr. Jane');


DELIMITER //
CREATE FUNCTION GenerateID(
    p_role INT,
    p_suffix INT,
    p_phone_suffix INT
)
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE generated_id INT;

    IF p_role = 1 THEN
        SET generated_id = CONCAT(1, LPAD(p_suffix, 2, '0'), LPAD(p_phone_suffix, 2, '0'));
    ELSEIF p_role = 2 THEN
        SET generated_id = CONCAT(2, p_suffix, LPAD(p_phone_suffix, 2, '0'));
    ELSEIF p_role = 3 THEN
        SET generated_id = CONCAT(3, p_suffix, LPAD(p_phone_suffix, 2, '0'));
    ELSE
        SET generated_id = NULL;
    END IF;

    RETURN CAST(generated_id AS SIGNED);
END //
DELIMITER ;
SELECT GenerateID(1, 123, 45) AS GeneratedID;
