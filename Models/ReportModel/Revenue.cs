namespace TTTN.Models.ReportModel
{
    public class Revenue
    {
        public string thang { get; set; }
        public string year { get; set; }
        public decimal revenue { get; set; }
    }

    public class RevenueReport
    {
        public string[] thoigian { get; set; }
        public decimal[] revenue { get; set; }

        public RevenueReport(int sp)
        {
            this.thoigian = new string[sp];
            this.revenue = new decimal[sp];
        }
    }
}
