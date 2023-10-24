
namespace Vectors
{
    public interface IVector
    {
        double X{ get; set; }
        double Y{ get; set; }
        double Z{ get; set; }

        double Length();
    }
}
