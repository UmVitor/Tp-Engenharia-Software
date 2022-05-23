CREATE DATABASE  IF NOT EXISTS `tp-engSoftware-database`
USE `tp-engSoftware-database`;

CREATE TABLE `filme` (
  `id_filme` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(200) NOT NULL,
  `Genero` varchar(500) NOT NULL,
  `Elenco` varchar(200) NOT NULL,  
  `Sinopse` varchar(4000) NOT NULL,
  `url_imagem` varchar(4000) DEFAULT NULL,
  PRIMARY KEY (`Id_filme`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

CREATE TABLE `usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `avaliacao` int DEFAULT NULL,
  `nickname` varchar(45) DEFAULT NULL,
  `comentario` VARCHAR(4000) DEFAULT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `avaliacao` (
  `id_avaliacao` int NOT NULL AUTO_INCREMENT,
  `id_filme` int NOT NULL,
  `id_usuario` int NOT NULL,
  PRIMARY KEY (`id_avaliacao`),
  CONSTRAINT `avaliacao_ibfk_1` FOREIGN KEY (`id_filme`) REFERENCES `filme` (`id_filme`),
  CONSTRAINT `avaliacao_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;