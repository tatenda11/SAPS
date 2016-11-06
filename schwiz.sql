-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 06, 2016 at 10:12 AM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 7.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `schwiz`
--

-- --------------------------------------------------------

--
-- Table structure for table `wizattendence`
--

CREATE TABLE `wizattendence` (
  `enrollmentId` varchar(25) NOT NULL,
  `termPeriod` varchar(25) NOT NULL,
  `totaldays` int(3) NOT NULL,
  `presentdays` int(3) NOT NULL,
  `absentdays` int(3) NOT NULL,
  `classId` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wizbalances`
--

CREATE TABLE `wizbalances` (
  `accountId` varchar(25) NOT NULL,
  `periodId` varchar(25) NOT NULL,
  `openBalance` double NOT NULL,
  `currentBalance` double NOT NULL,
  `closingBalance` double NOT NULL,
  `paymentIn` double NOT NULL,
  `paymentOut` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wizclassrooms`
--

CREATE TABLE `wizclassrooms` (
  `classRoomId` int(5) NOT NULL,
  `className` varchar(50) NOT NULL,
  `classGrade` int(2) NOT NULL,
  `teacherId` int(5) NOT NULL,
  `classDetails` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wizclassrooms`
--

INSERT INTO `wizclassrooms` (`classRoomId`, `className`, `classGrade`, `teacherId`, `classDetails`) VALUES
(1, 'Yellow', 7, 1, 'grade seven blue');

-- --------------------------------------------------------

--
-- Table structure for table `wizfeesbalances`
--

CREATE TABLE `wizfeesbalances` (
  `enrollmentId` varchar(25) NOT NULL,
  `termPeriod` varchar(25) NOT NULL,
  `OpenBal` double NOT NULL,
  `CurrentBal` double NOT NULL,
  `ClosingBal` double NOT NULL,
  `PaymentIn` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wizstudentdetails`
--

CREATE TABLE `wizstudentdetails` (
  `detailId` int(11) NOT NULL,
  `enrolmentId` varchar(15) NOT NULL,
  `address` text NOT NULL,
  `guardianFname` varchar(30) NOT NULL,
  `guardianSname` varchar(30) NOT NULL,
  `relationship` varchar(15) NOT NULL,
  `mobileNumber` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wizstudents`
--

CREATE TABLE `wizstudents` (
  `systemId` int(11) NOT NULL,
  `enrolmentId` varchar(25) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `middleName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `classId` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wiztransacations`
--

CREATE TABLE `wiztransacations` (
  `transId` varchar(20) NOT NULL,
  `transAccount` varchar(20) NOT NULL,
  `transType` enum('F','P') NOT NULL,
  `transAmount` double NOT NULL,
  `adminId` varchar(25) NOT NULL,
  `transDate` date NOT NULL,
  `transTerm` varchar(20) NOT NULL,
  `transPeriod` varchar(20) NOT NULL,
  `transDetails` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wizuser`
--

CREATE TABLE `wizuser` (
  `userId` int(5) NOT NULL,
  `userName` varchar(40) NOT NULL,
  `password` varchar(25) NOT NULL,
  `userType` enum('T','A','F','H') NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wizuser`
--

INSERT INTO `wizuser` (`userId`, `userName`, `password`, `userType`, `email`) VALUES
(8, 'tatenda', '10', 'T', 'tatemunenge@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `wizuserdetails`
--

CREATE TABLE `wizuserdetails` (
  `detailId` int(5) NOT NULL,
  `userId` int(5) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `phoneNumber` varchar(18) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `wizattendence`
--
ALTER TABLE `wizattendence`
  ADD PRIMARY KEY (`enrollmentId`,`termPeriod`);

--
-- Indexes for table `wizbalances`
--
ALTER TABLE `wizbalances`
  ADD PRIMARY KEY (`accountId`,`periodId`);

--
-- Indexes for table `wizclassrooms`
--
ALTER TABLE `wizclassrooms`
  ADD PRIMARY KEY (`classRoomId`);

--
-- Indexes for table `wizfeesbalances`
--
ALTER TABLE `wizfeesbalances`
  ADD PRIMARY KEY (`enrollmentId`,`termPeriod`);

--
-- Indexes for table `wizstudentdetails`
--
ALTER TABLE `wizstudentdetails`
  ADD PRIMARY KEY (`detailId`);

--
-- Indexes for table `wizstudents`
--
ALTER TABLE `wizstudents`
  ADD PRIMARY KEY (`systemId`);

--
-- Indexes for table `wizuser`
--
ALTER TABLE `wizuser`
  ADD PRIMARY KEY (`userId`);

--
-- Indexes for table `wizuserdetails`
--
ALTER TABLE `wizuserdetails`
  ADD PRIMARY KEY (`detailId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `wizclassrooms`
--
ALTER TABLE `wizclassrooms`
  MODIFY `classRoomId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `wizstudentdetails`
--
ALTER TABLE `wizstudentdetails`
  MODIFY `detailId` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `wizstudents`
--
ALTER TABLE `wizstudents`
  MODIFY `systemId` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `wizuser`
--
ALTER TABLE `wizuser`
  MODIFY `userId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `wizuserdetails`
--
ALTER TABLE `wizuserdetails`
  MODIFY `detailId` int(5) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
