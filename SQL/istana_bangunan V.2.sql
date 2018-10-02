-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 02 Okt 2018 pada 06.51
-- Versi Server: 10.1.28-MariaDB
-- PHP Version: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `istana_bangunan`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `barang`
--
CREATE DATABASE `istana_bangunan`;
USE `istana_bangunan`;

CREATE TABLE `barang` (
  `id_barang` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `nama_barang` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `merek_barang` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `harga_barang` int(11) NOT NULL,
  `jumlah_barang` int(11) NOT NULL,
  `lokasi_rak` varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `barang`
--

INSERT INTO `barang` (`id_barang`, `nama_barang`, `merek_barang`, `harga_barang`, `jumlah_barang`, `lokasi_rak`) VALUES
('bar1', 'Dancoklat', 'CoklatModern', 9000, 500, 'Rak123'),
('bar2', 'Dancoklat', 'CoklatModern', 9000, 500, 'Rak123');

-- --------------------------------------------------------

--
-- Struktur dari tabel `distributor`
--

CREATE TABLE `distributor` (
  `id_distributor` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `nama_distributor` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `distributor`
--

INSERT INTO `distributor` (`id_distributor`, `nama_distributor`) VALUES
('dist1', 'Kacung Kampret');

-- --------------------------------------------------------

--
-- Struktur dari tabel `distributor_barang`
--

CREATE TABLE `distributor_barang` (
  `id_distributor` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `id_barang` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `distributor_barang`
--

INSERT INTO `distributor_barang` (`id_distributor`, `id_barang`) VALUES
('dist1', 'bar1');

-- --------------------------------------------------------

--
-- Struktur dari tabel `karyawan`
--

CREATE TABLE `karyawan` (
  `id_karyawan` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `nama_karyawan` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `jenis_kelamin` enum('laki-laki','perempuan','','') COLLATE utf8_unicode_ci NOT NULL,
  `gaji_karyawan` int(11) NOT NULL,
  `lama_bekerja` int(11) NOT NULL,
  `cabang_tempat_bekerja` varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `toko`
--

CREATE TABLE `toko` (
  `id_toko` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `nama_toko` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `toko`
--

INSERT INTO `toko` (`id_toko`, `nama_toko`) VALUES
('toko1', 'Istana Bangunan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `toko_menjual`
--

CREATE TABLE `toko_menjual` (
  `id_toko` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `id_barang` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `toko_menjual`
--

INSERT INTO `toko_menjual` (`id_toko`, `id_barang`) VALUES
('toko1', 'bar2');

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `id` varchar(20) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`id`, `username`, `password`) VALUES
('d123', 'yusril', '1234');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`id_barang`);

--
-- Indexes for table `distributor`
--
ALTER TABLE `distributor`
  ADD PRIMARY KEY (`id_distributor`);

--
-- Indexes for table `distributor_barang`
--
ALTER TABLE `distributor_barang`
  ADD KEY `dist_bar_fk1` (`id_distributor`),
  ADD KEY `dist_bar_fk2` (`id_barang`);

--
-- Indexes for table `karyawan`
--
ALTER TABLE `karyawan`
  ADD PRIMARY KEY (`id_karyawan`),
  ADD UNIQUE KEY `id_karyawan` (`id_karyawan`);

--
-- Indexes for table `toko`
--
ALTER TABLE `toko`
  ADD PRIMARY KEY (`id_toko`);

--
-- Indexes for table `toko_menjual`
--
ALTER TABLE `toko_menjual`
  ADD PRIMARY KEY (`id_toko`),
  ADD KEY `toko_menjual_fk1` (`id_toko`),
  ADD KEY `toko_menjual_fk2` (`id_barang`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `distributor_barang`
--
ALTER TABLE `distributor_barang`
  ADD CONSTRAINT `dist_bar_fk1` FOREIGN KEY (`id_distributor`) REFERENCES `distributor` (`id_distributor`),
  ADD CONSTRAINT `dist_bar_fk2` FOREIGN KEY (`id_barang`) REFERENCES `barang` (`id_barang`);

--
-- Ketidakleluasaan untuk tabel `toko_menjual`
--
ALTER TABLE `toko_menjual`
  ADD CONSTRAINT `toko_menjual_fk1` FOREIGN KEY (`id_toko`) REFERENCES `toko` (`id_toko`),
  ADD CONSTRAINT `toko_menjual_fk2` FOREIGN KEY (`id_barang`) REFERENCES `barang` (`id_barang`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
