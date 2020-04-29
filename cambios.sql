CREATE TABLE `caja`.`tbapagos` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idfpago` INT NOT NULL,
  `id_compra` INT NOT NULL,
  `fecha` DATETIME NOT NULL,
  `monto` DOUBLE NOT NULL,
  PRIMARY KEY (`id`));
ALTER TABLE `caja`.`tbaproductos` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL DEFAULT 0 ;
ALTER TABLE `caja`.`tbadetajustes` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL ;
ALTER TABLE `caja`.`tbadetcompras` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL ;
ALTER TABLE `caja`.`tbadetentradas` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL ;
ALTER TABLE `caja`.`tbadetsalidas` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL ;
ALTER TABLE `caja`.`tbadetticket` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL ;
ALTER TABLE `caja`.`tbadettrans` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL ;
ALTER TABLE `caja`.`tbakardex` 
CHANGE COLUMN `cantidad` `cantidad` DOUBLE(10,2) NOT NULL ,
CHANGE COLUMN `antes` `antes` DOUBLE(10,2) NOT NULL ;
