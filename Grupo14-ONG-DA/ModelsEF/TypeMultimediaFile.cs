
namespace Grupo14_ONG_DA.ModelsEF
{
    public class TypeMultimediaFile
    {

        public enum enumTypeMultimediaFile
        {
            Image = 1,
            Gif =   2,
            Video = 3,

        }

        public int Id { get; set; }
        
        public enumTypeMultimediaFile TypeMultimedia { get; set; }
    }
}