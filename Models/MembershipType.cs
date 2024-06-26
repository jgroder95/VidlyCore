﻿namespace VidlyCore.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public byte SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
