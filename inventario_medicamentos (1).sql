-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 02-09-2022 a las 23:15:22
-- Versión del servidor: 5.7.36
-- Versión de PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `inventario_medicamentos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE IF NOT EXISTS `clientes` (
  `id_cliente` int(11) NOT NULL AUTO_INCREMENT,
  `nom_cliente` varchar(100) NOT NULL,
  `ape_cliente` varchar(100) NOT NULL,
  `nit` varchar(13) NOT NULL,
  `telefono_cliente` varchar(8) NOT NULL,
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`id_cliente`, `nom_cliente`, `ape_cliente`, `nit`, `telefono_cliente`) VALUES
(1, 'Marco', 'Sosa', '345678890', '54689098'),
(3, 'Juana', 'Kiki', '12324435', '24233244'),
(4, 'j', 'o', '8', '9');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compra`
--

DROP TABLE IF EXISTS `compra`;
CREATE TABLE IF NOT EXISTS `compra` (
  `id_compra` int(11) NOT NULL AUTO_INCREMENT,
  `fec_compra` date NOT NULL,
  `precio_costo` varchar(10) NOT NULL,
  `unidades_compradas` int(11) NOT NULL,
  `id_proveedores` int(11) NOT NULL,
  `id_medicamento` int(11) NOT NULL,
  `total` double DEFAULT NULL,
  `precio_final` double DEFAULT NULL,
  PRIMARY KEY (`id_compra`),
  KEY `proveedores` (`id_proveedores`),
  KEY `index_med` (`id_medicamento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `login`
--

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `id_login` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(50) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `pssw` varchar(30) NOT NULL,
  `id_rol` int(11) NOT NULL,
  PRIMARY KEY (`id_login`),
  KEY `ol` (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `login`
--

INSERT INTO `login` (`id_login`, `usuario`, `nombre`, `pssw`, `id_rol`) VALUES
(2, 'Juana Sosa', 'Admin1', '123', 1),
(4, 'Admin3', 'María', '45', 4),
(5, 'Admin1', 'Luisa', '234', 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `marca`
--

DROP TABLE IF EXISTS `marca`;
CREATE TABLE IF NOT EXISTS `marca` (
  `id_marca` int(11) NOT NULL AUTO_INCREMENT,
  `nom_marca` varchar(100) NOT NULL,
  `calificacion` varchar(1) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  PRIMARY KEY (`id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `marca`
--

INSERT INTO `marca` (`id_marca`, `nom_marca`, `calificacion`, `direccion`) VALUES
(1, 'Nutricia', '5', '2 calle 2-010 Zona 3 Guatemala, Guatemala.'),
(3, 'fr', '2', 'd'),
(4, 'Juana', '1', '0 calle 2'),
(5, 'jjj', '1', '0 calle 2'),
(7, 'Junio', '3', '0 calle 3-080 Zona 2 salcaja.');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `medicamento`
--

DROP TABLE IF EXISTS `medicamento`;
CREATE TABLE IF NOT EXISTS `medicamento` (
  `id_med` int(11) NOT NULL AUTO_INCREMENT,
  `nom_med` varchar(100) NOT NULL,
  `receta` tinyint(1) NOT NULL,
  `Cantidad_existente` int(11) NOT NULL,
  `precauciones` varchar(200) NOT NULL,
  `descripcion` varchar(200) NOT NULL,
  `fec_caducidad` date NOT NULL,
  `presentacion` varchar(100) NOT NULL,
  `uni_medida` varchar(100) NOT NULL,
  `formula` varchar(200) NOT NULL,
  `dosis` varchar(100) NOT NULL,
  PRIMARY KEY (`id_med`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `medicamento`
--

INSERT INTO `medicamento` (`id_med`, `nom_med`, `receta`, `Cantidad_existente`, `precauciones`, `descripcion`, `fec_caducidad`, `presentacion`, `uni_medida`, `formula`, `dosis`) VALUES
(2, '1', 1, 467, '1', '1', '2024-02-06', '0', '1', '1', '1'),
(3, '1', 0, 13, '7', '8', '2022-09-01', '3', '4', '5', '6'),
(4, 'q', 1, 12, 'werty', 'dsfgsgfd', '2022-09-01', 'qwe', 'asd', 'lkjh', 'nbvc'),
(5, 'Hi', 0, 45, 'jakncdjka', 'cnjdfkal', '2022-09-05', 'r', 'd', 'jfioewñ', 'fnkjsñ'),
(6, 'yuiutj', 1, 34, '1', '1', '2024-02-06', '0', '1', '1', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
CREATE TABLE IF NOT EXISTS `proveedores` (
  `id_proveedores` int(11) NOT NULL AUTO_INCREMENT,
  `nom_proveedores` varchar(100) NOT NULL,
  `telefono` varchar(8) NOT NULL,
  `id_marca` int(11) NOT NULL,
  PRIMARY KEY (`id_proveedores`),
  KEY `Marca` (`id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`id_proveedores`, `nom_proveedores`, `telefono`, `id_marca`) VALUES
(1, 'Edgar Raúl Culajay', '01726394', 1),
(3, 'Marco Sosa', '12345456', 1),
(4, 'ser', '12234354', 4),
(5, 'kiki', '98765432', 7),
(6, 'gyr', '08765453', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

DROP TABLE IF EXISTS `rol`;
CREATE TABLE IF NOT EXISTS `rol` (
  `id_rol` int(11) NOT NULL AUTO_INCREMENT,
  `rol` varchar(20) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `rol`
--

INSERT INTO `rol` (`id_rol`, `rol`) VALUES
(1, 'Administrador.'),
(4, 'Empleado.');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `venta`
--

DROP TABLE IF EXISTS `venta`;
CREATE TABLE IF NOT EXISTS `venta` (
  `id_venta` int(11) NOT NULL AUTO_INCREMENT,
  `fec_venta` date NOT NULL,
  `unidades_vendidas` int(11) NOT NULL,
  `subtotal_venta` double DEFAULT NULL,
  `id_cliente` int(11) NOT NULL,
  `id_medicamento` int(11) NOT NULL,
  `id_compra` int(11) NOT NULL,
  PRIMARY KEY (`id_venta`),
  KEY `cliente_index` (`id_cliente`),
  KEY `index_med` (`id_medicamento`),
  KEY `index_compra` (`id_compra`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `compra`
--
ALTER TABLE `compra`
  ADD CONSTRAINT `compra_ibfk_2` FOREIGN KEY (`id_proveedores`) REFERENCES `proveedores` (`id_proveedores`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `compra_ibfk_3` FOREIGN KEY (`id_medicamento`) REFERENCES `medicamento` (`id_med`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `login_ibfk_1` FOREIGN KEY (`id_rol`) REFERENCES `rol` (`id_rol`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD CONSTRAINT `proveedores_ibfk_1` FOREIGN KEY (`id_marca`) REFERENCES `marca` (`id_marca`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `venta`
--
ALTER TABLE `venta`
  ADD CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `venta_ibfk_3` FOREIGN KEY (`id_medicamento`) REFERENCES `medicamento` (`id_med`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
