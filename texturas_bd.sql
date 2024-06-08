-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-06-2024 a las 19:11:07
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `texturas_bd`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `texturas`
--

CREATE TABLE `texturas` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `red` int(11) NOT NULL,
  `green` int(11) NOT NULL,
  `blue` int(11) NOT NULL,
  `color` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `texturas`
--

INSERT INTO `texturas` (`id`, `descripcion`, `red`, `green`, `blue`, `color`) VALUES
(49, 'Blanco', 254, 254, 254, 'Teal'),
(50, 'violeta', 207, 50, 163, 'Black'),
(51, 'fondo', 238, 233, 229, 'Red'),
(52, 'chompa', 151, 134, 127, '#FF8000'),
(53, 'chompa', 124, 107, 101, '#FF8000'),
(54, 'chompa', 124, 107, 101, '#FF8000'),
(55, 'chompa', 123, 106, 101, '#FF8000'),
(56, 'chompa', 123, 106, 101, '#FF8000');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `texturas`
--
ALTER TABLE `texturas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `texturas`
--
ALTER TABLE `texturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
