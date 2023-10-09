using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntiyLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccesLayer
{
    public class DALDers
    {
        public static List<EntityDers> DersListesi()
        {
            List<EntityDers> degerler = new List<EntityDers>();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Dersler", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityDers ent = new EntityDers();
                ent.ID = Convert.ToInt32(oku["dersID"].ToString());
                ent.DERSAD = oku["dersAd"].ToString();
                ent.MIN = Convert.ToInt32(oku["dersMinKontenjan"].ToString());
                ent.MAX = int.Parse(oku["dersMaxKontenjan"].ToString());
                degerler.Add(ent);
            }
            oku.Close();
            return degerler;
        }
        public static int TalepEkle(EntityBasvuruForm p)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_BasvuruForm (ogrenciID, dersID) values (@p1,@p2)", Baglanti.bgl);
            komut.Parameters.AddWithValue("@p1", p.BASOGRID);
            komut.Parameters.AddWithValue("@p2", p.BASDERSID);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            return komut.ExecuteNonQuery();
        }
    }
}
