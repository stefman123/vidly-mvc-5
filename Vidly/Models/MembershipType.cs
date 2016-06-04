namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }


        //based on membership type values in the database or could use Enums as well
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}