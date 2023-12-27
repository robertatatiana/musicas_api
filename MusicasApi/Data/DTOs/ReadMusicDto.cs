using System.ComponentModel.DataAnnotations;

namespace MusicasApi.Data.DTOs
{
    public class ReadMusicDto
    {
        public string Name { get; set; }

        public string Band { get; set; }

        public int Duration { get; set; }

        public DateTime TimeOfConsultation { get; set; } = DateTime.Now;
    }
}
