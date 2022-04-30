-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema ade
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ade
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ade` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `ade` ;

-- -----------------------------------------------------
-- Table `ade`.`korisnici`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ade`.`korisnici` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `Ime` VARCHAR(45) NOT NULL,
  `Prezime` VARCHAR(45) NOT NULL,
  `JMBG` VARCHAR(45) NOT NULL,
  `ZIP` VARCHAR(45) NOT NULL,
  `CVV` VARCHAR(45) NOT NULL,
  `datumRodjenja` DATE NOT NULL,
  `role` ENUM('Administrator', 'Korisnik') NOT NULL DEFAULT 'Korisnik',
  `datumKreiranjaRacuna` DATE NULL DEFAULT curdate(),
  `datumIstekaRacuna` DATE NULL DEFAULT (curdate() + interval 5 year),
  PRIMARY KEY (`id`),
  UNIQUE INDEX `CVV_UNIQUE` (`CVV` ASC) VISIBLE,
  UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ade`.`kredit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ade`.`kredit` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(30) NOT NULL,
  `cifra` INT NOT NULL,
  `validanKredit` ENUM('Da', 'Ne') NULL DEFAULT 'Ne',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
