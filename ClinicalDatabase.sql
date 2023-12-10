CREATE DATABASE ClinicalDatabase;
USE ClinicalDatabase;

CREATE TABLE USER (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Gender VARCHAR(10),
    BirthDate DATE,
    Email VARCHAR(255),
    PhoneNumber INT,
    Address VARCHAR(255),
    About VARCHAR(255),
    Age INT
);
DELIMITER //
CREATE TRIGGER calculate_age_user
BEFORE INSERT ON USER
FOR EACH ROW
BEGIN
    SET NEW.Age = TIMESTAMPDIFF(YEAR, NEW.BirthDate, CURDATE());
END;
//
DELIMITER ;


CREATE TABLE PATIENT (
    PatientID INT PRIMARY KEY AUTO_INCREMENT,
    PatientType VARCHAR(255),
    BirthDate DATE,
    Address VARCHAR(255),
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    OtherContact VARCHAR(255), 
    PhoneNumber INT,
    Age INT
);
DELIMITER //
CREATE TRIGGER calculate_age_patient
BEFORE INSERT ON Patient
FOR EACH ROW
BEGIN
    SET NEW.Age = TIMESTAMPDIFF(YEAR, NEW.BirthDate, CURDATE());
END;
// 
DELIMITER ;


CREATE TABLE LOGIN (
    UserID INT,
    Username VARCHAR(255) UNIQUE,
    Password VARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES USER(UserID)
);


CREATE TABLE REPORT (
    ReportID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT,
    DoctorID INT,
    ReportDateAndTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    SessionNumber INT,
    TreatmentStage VARCHAR(255),
    FOREIGN KEY (DoctorID) REFERENCES USER(UserID),
    FOREIGN KEY (PatientID) REFERENCES PATIENT(PatientID)
);


CREATE TABLE CAMERA(
	CameraID INT PRIMARY KEY AUTO_INCREMENT,
    Brand VARCHAR(255),
    Model VARCHAR(255),
    ViewDateAndTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ViewDescription VARCHAR(255)
);


CREATE TABLE ATTENDANCE (
    UserID INT PRIMARY KEY,
    TimeofArrival TIME,
    TimeofLeave TIME,
    DateofTheDay DATE,
    Absence VARCHAR(255),
    Excuse VARCHAR(255),
    TotalHoursWorking INT,
    FOREIGN KEY (UserID) REFERENCES USER(UserID)
);


CREATE TABLE APPOINTMENTS (
    AppointmentID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    BirthDate DATE,
    Gender VARCHAR(10),
    DoctorID INT,
    AppointmentDate DATE,
    AppointmentTime TIME,
    Address VARCHAR(255),
    Email VARCHAR(255),
    PhoneNumber INT,
    ReferralDoctor VARCHAR(255),
    ClinicReferralDoctorID INT,
    Insurance VARCHAR(255),
    StateOfPatient VARCHAR(255),
    FOREIGN KEY (DoctorID) REFERENCES USER(UserID),
    FOREIGN KEY (ClinicReferralDoctorID) REFERENCES USER(UserID)
);


CREATE TABLE ASSESSMENT (
    AssessmentID INT PRIMARY KEY,
    DoctorOrReceptionID INT,
    PatientAge INT,
    PatientComplain VARCHAR(255),
    BodyPart VARCHAR(255),
    InjuryType VARCHAR(255),
    TreatmentPlan VARCHAR(255),
    FOREIGN KEY (DoctorOrReceptionID) REFERENCES USER(UserID)
);


CREATE TABLE MEDICAL_HISTORY (
    PatientID INT PRIMARY KEY,
    Surgiers VARCHAR(255),
    Illness VARCHAR(255),
    FamilyMedicalBackground VARCHAR(255)
);


CREATE TABLE PATIENT_DATA (
    PatientID INT,
    AssessmentID INT,
    ReportID INT,
    PRIMARY KEY (PatientID, AssessmentID, ReportID),
    FOREIGN KEY (PatientID) REFERENCES PATIENT(PatientID),
    FOREIGN KEY (AssessmentID) REFERENCES ASSESSMENT(AssessmentID),
    FOREIGN KEY (ReportID) REFERENCES REPORT(ReportID),
    FOREIGN KEY (PatientID) REFERENCES MEDICAL_HISTORY(PatientID)
);


