-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 21-09-2022 a las 04:54:07
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`id_cliente`, `nom_cliente`, `ape_cliente`, `nit`, `telefono_cliente`) VALUES
(1, 'Jose Luis ', 'Moreira Vides', '345678890', '54689098'),
(2, 'Ivonee Susseth', ' Godinez Miranda ', '12324435', '98765432'),
(3, 'Ingrid Lorena', 'Juarez Ochoa', '81234567', '90987654'),
(4, 'Sheyla Marleni', 'Garcia Solares', '08989786', '12345456'),
(5, 'Yanely ', 'Villagran De León', '17320823', '54267800');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compra`
--

DROP TABLE IF EXISTS `compra`;
CREATE TABLE IF NOT EXISTS `compra` (
  `id_compra` int(11) NOT NULL AUTO_INCREMENT,
  `fec_compra` date NOT NULL,
  `precio_costo` double NOT NULL,
  `unidades_compradas` int(11) NOT NULL,
  `id_proveedores` int(11) NOT NULL,
  `id_medicamento` int(11) NOT NULL,
  `total` double DEFAULT NULL,
  `precio_final` double DEFAULT NULL,
  `total_PC` double NOT NULL,
  PRIMARY KEY (`id_compra`),
  KEY `proveedores` (`id_proveedores`),
  KEY `index_med` (`id_medicamento`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `compra`
--

INSERT INTO `compra` (`id_compra`, `fec_compra`, `precio_costo`, `unidades_compradas`, `id_proveedores`, `id_medicamento`, `total`, `precio_final`, `total_PC`) VALUES
(1, '2022-09-08', 95, 15, 1, 1, 2250, 150, 1425),
(2, '2022-09-06', 25, 45, 4, 2, 2250, 50, 1125),
(3, '2022-09-09', 13, 10, 1, 3, 500, 50, 130),
(4, '2022-09-12', 10, 50, 3, 4, 1750, 35, 500),
(5, '2022-09-14', 10, 25, 2, 5, 1650, 66, 250),
(6, '2022-09-16', 100, 40, 5, 6, 6400, 160, 4000),
(7, '2022-09-20', 32, 85, 6, 7, 3825, 45, 2720),
(8, '2022-09-20', 100, 90, 7, 8, 52200, 580, 9000);

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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `login`
--

INSERT INTO `login` (`id_login`, `usuario`, `nombre`, `pssw`, `id_rol`) VALUES
(1, 'JS', 'Juana Sosa', 'Juana1202', 1),
(2, 'MF', 'María Fuentes', 'Fue34', 2),
(3, 'LM', 'Luisa Morales', '03112007', 3),
(4, 'OP', 'Oliva Pereira', '12345', 4),
(5, '1', 'Yuliana Soto', '1', 1),
(6, 'MI', 'Mariella Ixquiac', 'Mi123', 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `marca`
--

INSERT INTO `marca` (`id_marca`, `nom_marca`, `calificacion`, `direccion`) VALUES
(1, 'Nutricia', '5', '2 calle 2-010 Zona 3 Guatemala, Guatemala.'),
(2, 'Roche', '2', '3 calle 3-100 Zona 4 Guatemala, Guatemala.'),
(3, 'Bayer', '1', '0 calle 2-100 Zona 6 Guatemala, Guatemala.'),
(4, 'Abbott', '5', '1 calle 6-078 Zona 15 Guatemala, Guatemala.'),
(6, 'Sanofy', '3', '0 calle 3-080 Zona 2 Guatemala, Guatemala.');

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
  `precio_costo` double NOT NULL,
  `precio_final` double NOT NULL,
  PRIMARY KEY (`id_med`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `medicamento`
--

INSERT INTO `medicamento` (`id_med`, `nom_med`, `receta`, `Cantidad_existente`, `precauciones`, `descripcion`, `fec_caducidad`, `presentacion`, `uni_medida`, `formula`, `dosis`, `precio_costo`, `precio_final`) VALUES
(1, 'Captamicina', 1, 10, 'Consultar en embarazo y lactancia.\r\nProducir colitis pseudomembranosa.', 'Hipersensibilidad a algun elemento.', '2024-01-01', 'Cápsulas.', '300 mg.', '-', '1 cápsula al día.', 95, 150),
(2, 'GastroBismol', 0, 5, 'Embarazo, lactancia, diabetes, gota y si esta en tratamiento con anticoagulantes.', 'Efectividad contra la diarrea, dispepsia, indigestión, náusea y flatulencias.', '2024-01-01', 'Oral.', '145 ml.', 'Cada 15 ml contiene: subsaliciato de bismuto 262 mg.', '2 cucharadas para adulros.', 25, 50),
(3, 'Vitaminas C + D', 0, 20, '-', '-', '2022-11-01', 'Barras de gelatina.', '15 ml.', 'Zinc 10 mg, Vit. C 250 mg Vit. D 25 mcg.', '1 barra.', 13, 50),
(4, 'Activirex', 1, 50, 'Evitar en ojos, boca y embarazo.', 'Fuera del alcance de niños. ', '2023-06-05', 'Crema.', '5 g.', 'Aciclovir 5g, excipientes c.s.p 100g.', '5 veces al día en lesiones.', 10, 35),
(5, 'Paracetamol', 0, 20, 'Evitar en tratamientos con anemia, afecciones cardíacas o pulmonares, o disfunción renal.', '-', '2026-07-06', 'Tabletas', '500 mg.', 'C8H9NO2', '1 ó 2 cápsula  de 3 a 4 veces al día.', 10, 66),
(6, 'Otrozol', 1, 20, 'No en embarazadas y suspender otro activo al colocar Otozol.', '-', '2024-02-01', 'Intravenosa.', '500 mg / 100 ml.', 'Metronidazol 5000 mg, Vehiculo cbp 100 ml. ', 'El frasco completo.', 100, 160),
(7, 'Bonerit', 1, 80, 'Mantengase fuera del alcance de los niños ', 'Almacenar a temperatura menor a 30°C ', '2024-02-29', 'Cápsulas Oral', '10 ml', 'Desloratadina 5.0 mg ; Eipiente c.s.p  1 tab', 'Según indicación del Médico', 32, 45),
(8, 'Dexidian', 0, 70, '-', '-', '2022-09-02', 'Cápsulas.', '60 mg.', 'Dexlansoprazol 60 mg.', '1 cápsula al día.', 100, 580);

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`id_proveedores`, `nom_proveedores`, `telefono`, `id_marca`) VALUES
(1, 'Edgar Raúl Culajay', '01726394', 1),
(2, 'Marco Edgar Elias Sosa', '12345456', 2),
(3, 'Rony David Salazar Barrios', '12234354', 3),
(4, 'Maritza Noemi Molina Orellana de Garcia', '98765432', 6),
(5, ' Maria Teresa Echeverria de Leon', '08765453', 4),
(6, 'Maxi Kulias', '48315950', 2),
(7, ' Maria Echeverria de Leon', '00989876', 1);

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
(2, 'Empleado.'),
(3, 'Secretaria.'),
(4, 'Contador.');

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
  `total` double NOT NULL,
  `unidades_compradas` int(11) NOT NULL,
  `precio` double NOT NULL,
  PRIMARY KEY (`id_venta`),
  KEY `cliente_index` (`id_cliente`),
  KEY `index_med` (`id_medicamento`)
) ENGINE=InnoDB AUTO_INCREMENT=131 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `venta`
--

INSERT INTO `venta` (`id_venta`, `fec_venta`, `unidades_vendidas`, `subtotal_venta`, `id_cliente`, `id_medicamento`, `total`, `unidades_compradas`, `precio`) VALUES
(1, '2022-09-20', 5, 750, 1, 1, 750, 10, 150),
(2, '2022-09-20', 5, 330, 1, 5, 1080, 20, 66),
(3, '2022-09-20', 10, 450, 1, 7, 1530, 80, 45),
(4, '2022-09-20', 1, 580, 2, 8, 580, 90, 580),
(5, '2022-09-20', 12, 1920, 2, 6, 2500, 28, 160),
(6, '2022-09-20', 15, 8700, 3, 8, 8700, 75, 580),
(7, '2022-09-20', 2, 100, 4, 3, 100, 20, 50),
(8, '2022-09-20', 8, 1280, 4, 6, 1380, 20, 160),
(9, '2022-09-20', 5, 2900, 5, 8, 2900, 70, 580),
(10, '2022-09-20', 45, 2250, 5, 2, 5150, 5, 50);

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
