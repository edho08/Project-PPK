using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PPK
{
    partial class CRUDGeneral
    {
        QueryBuilder READ = new QueryBuilder();
        QueryBuilder UPDATE = new QueryBuilder();
        QueryBuilder CREATE = new QueryBuilder();
        QueryBuilder DELETE = new QueryBuilder();
        
        //ARGS


        void buildQuery() {
            Dictionary<string, System.Windows.Forms.TextBox> karyawan_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@nama_karyawan", tb_karyawan_nama }, { "@jenis_kelamin", tb_karyawan_kelamin }, { "@gaji_karyawan", tb_karyawan_gaji }, { "@lama_bekerja", tb_karyawan_lama }, { "@cabang_tempat_bekerja", tb_karyawan_tempat }, { "@id_karyawan", tb_karyawan_id } };
            Dictionary<string, System.Windows.Forms.TextBox> toko_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@id_toko", tb_toko_id}, { "@nama_toko", tb_toko_nama } };
            Dictionary<string, System.Windows.Forms.TextBox> barang_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@id_barang", tb_barang_id}, {"@nama_barang", tb_barang_nama }, { "@merek_barang", tb_barang_merk},{ "@harga_barang", tb_barang_harga},{ "@jumlah_barang", tb_barang_jumlah},{"@lokasi_rak", tb_barang_rak }};
            Dictionary<string, System.Windows.Forms.TextBox> distributor_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@id_distributor", tb_dist_id },{ "@nama_distributor", tb_dist_nama } };
            Dictionary<string, System.Windows.Forms.TextBox> distributor_barang_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@id_distributor", tb_brgdist_id_dist },{ "@id_barang", tb_brgdist_id_brg } };
            Dictionary<string, System.Windows.Forms.TextBox> toko_menjual_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@id_toko", tb_tkmjl_id_toko },{ "@id_barang", tb_tkmjl_id_barang } };


            //READ
            READ.query.Add("karyawan", "SELECT * FROM karyawan");
            READ.query.Add("toko", "SELECT * FROM toko");
            READ.query.Add("barang", "SELECT * FROM barang");
            READ.query.Add("distributor", "SELECT * FROM distributor");
            READ.query.Add("distributor_barang", "SELECT * FROM distributor_barang");
            READ.query.Add("toko_menjual", "SELECT * FROM toko_menjual");

            //UPDATE
            UPDATE.query.Add("karyawan", "UPDATE `karyawan` SET `nama_karyawan`=@nama_karyawan,`jenis_kelamin`=@jenis_kelamin,`gaji_karyawan`=@gaji_karyawan,`lama_bekerja`=@lama_bekerja,`cabang_tempat_bekerja`=@cabang_tempat_bekerja WHERE `id_karyawan`=@id_karyawan");
            UPDATE.query.Add("barang", "UPDATE `barang` SET `nama_barang`=@nama_barang,`merek_barang`=@merek_barang,`harga_barang`=@harga_barang,`jumlah_barang`=@jumlah_barang,`lokasi_rak`=@lokasi_rak WHERE `id_barang`=@id_barang");
            UPDATE.query.Add("distributor", "UPDATE `distributor` SET `nama_distributor`=@nama_distributor WHERE `id_distributor`=@id_distributor");
            //UPDATE.query.Add("distributor_barang", "UPDATE `distributor_barang` SET `id_barang`=@id_barang WHERE `id_distributor`=@id_distributor");
            UPDATE.query.Add("toko", "UPDATE `toko` SET `nama_toko`=@nama_toko WHERE `id_toko`=@id_toko");
           //UPDATE.query.Add("toko_menjual", "UPDATE `toko_menjual` SET `id_barang`=[value-2] WHERE 1");

            UPDATE.args_box.Add("karyawan", karyawan_args);
            UPDATE.args_box.Add("barang", barang_args);
            UPDATE.args_box.Add("distributor", distributor_args);
            UPDATE.args_box.Add("distributor_barang", distributor_barang_args);
            UPDATE.args_box.Add("toko", toko_args);
            UPDATE.args_box.Add("toko_menjual", toko_menjual_args);

            //CREATE
            CREATE.query.Add("karyawan", "INSERT INTO `karyawan`(`id_karyawan`, `nama_karyawan`, `jenis_kelamin`, `gaji_karyawan`, `lama_bekerja`, `cabang_tempat_bekerja`) VALUES (@id_karyawan,@nama_karyawan,@jenis_kelamin,@gaji_karyawan,@lama_bekerja,@cabang_tempat_bekerja)");
            CREATE.query.Add("barang", "INSERT INTO `barang`(`id_barang`, `nama_barang`, `merek_barang`, `harga_barang`, `jumlah_barang`, `lokasi_rak`) VALUES (@id_barang, @nama_barang, @merek_barang, @harga_barang, @jumlah_barang, @lokasi_rak)");
            CREATE.query.Add("distributor", "INSERT INTO `distributor`(`id_distributor`, `nama_distributor`) VALUES (@id_distributor, @nama_distributor)");
            CREATE.query.Add("distributor_barang", "INSERT INTO `distributor_barang`(`id_distributor`, `id_barang`) VALUES (@id_distributor, @id_barang)");
            CREATE.query.Add("toko", "INSERT INTO `toko`(`id_toko`, `nama_toko`) VALUES (@id_toko, @nama_toko)");
            CREATE.query.Add("toko_menjual", "INSERT INTO `toko_menjual`(`id_toko`, `id_barang`) VALUES (@id_toko, @id_barang)");

            CREATE.args_box.Add("karyawan", karyawan_args);
            CREATE.args_box.Add("barang", barang_args);
            CREATE.args_box.Add("distributor", distributor_args);
            CREATE.args_box.Add("distributor_barang", distributor_barang_args);
            CREATE.args_box.Add("toko", toko_args);
            CREATE.args_box.Add("toko_menjual", toko_menjual_args);

            //DELETE
            DELETE.query.Add("karyawan", "DELETE FROM `karyawan` WHERE `id_karyawan`= @id_karyawan");
            DELETE.query.Add("barang", "DELETE FROM `barang` WHERE `id_barang`=@id_barang");
            DELETE.query.Add("distributor", "DELETE FROM `distributor` WHERE `id_distributor`=@id_distributor");
            DELETE.query.Add("distributor_barang", "DELETE FROM `distributor_barang` WHERE `id_distributor`=@id_distributor AND `id_barang`=@id_barang");
            DELETE.query.Add("toko", "DELETE FROM `toko` WHERE `id_toko`=@id_toko");
            DELETE.query.Add("toko_menjual", "DELETE FROM `toko_menjual` WHERE `id_barang` = @id_barang AND `id_toko` = @id_toko");
            DELETE.args_box.Add("karyawan", karyawan_args);
            DELETE.args_box.Add("barang", barang_args);
            DELETE.args_box.Add("distributor", distributor_args);
            DELETE.args_box.Add("distributor_barang", distributor_barang_args);
            DELETE.args_box.Add("toko", toko_args);
            DELETE.args_box.Add("toko_menjual", toko_menjual_args);
        }

        Dictionary<string, string> getArgs(QueryBuilder op,string table) {
            Dictionary<string, string> args = new Dictionary<string, string>();
            foreach (KeyValuePair<string, System.Windows.Forms.TextBox> entry in op.args_box[table]) {
                args.Add(entry.Key, entry.Value.Text);
            }
            return args;
        }
    }
}
