namespace StudentRegistrationApp
{
    public class Mahasiswa
    {
        public string NIM { get; set; } = "";
        public string Nama { get; set; } = "";
        public string Jurusan { get; set; } = "";
        public string JenisKelamin { get; set; } = "";
        public string Alamat { get; set; } = "";

        public override string ToString()
        {
            return $"{NIM} | {Nama} | {Jurusan} | {JenisKelamin}";
        }
    }
}