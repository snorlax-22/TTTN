using System.Collections.Generic;
using System;

namespace BT2MWG.Models
{
    [Serializable]
    public class Search
    {
        public int ManuId { get; set; }

        // dùng để filter hãng trang phụ kiện chính hãng
        public string ManuName { get; set; }
        public bool IsManuNameFilter { get; set; }
        public int StoreId { get; set; }
        public List<int> ListManuId { get; set; }
        public string StrListManuId { get; set; }
        public string ManuUrl { get; set; }
        public int PriceId { get; set; }
        //public PriceRange PriceRange { get; set; }
        public string RangeUrl { get; set; }
        public List<int> ListRangeId { get; set; }
        public string StrListRangeId { get; set; }

        public List<int> LstProp = new List<int>();
        public string PropUrl { get; set; }
        public List<int> CategoryListIds { get; set; }
        public int OrderType { get; set; }
        public int AdditionFilter { get; set; }
        public string Extension { get; set; }
        public List<string> OrderTypeValue { get; set; }
        public List<string> SearchFlags { get; set; }
        public int CategoryId { get; set; }
        public int BlueSportId { get; set; }
        public int PropId { get; set; }
        public string StrPropID { get; set; }
        public int PropValueId { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public bool IsLuxuryWatch { get; set; }
        public bool IsAccessoryGenuine { get; set; }
        public bool IsWatchPage { get; set; }
        public bool IsBicyclePage { get; set; }
        public bool IsSmartWatchPage { get; set; }
        public bool IsBlueJiPage { get; set; }
        public string ExtendFilter { get; set; }
        public bool IsWaterPurifierPage { get; set; }
        public bool IsLDPNew2021 { get; set; }
        public bool IsNoDataFromPriceQuery { get; set; }
        public bool IsNoDataFromPropQuery { get; set; }
        public bool IsWrongSmoothUrl { get; set; }
        public string StrRangePriceMinMax { get; set; }
        //public List<PropertyDetailFilters> ListPropDetailFilters { get; set; }
        public int GenderId { get; set; }
        public string StrListGender { get; set; }
        public string StrListStyle { get; set; }
        public List<int> ListGenderId { get; set; }
        public int SportId { get; set; }
        public string StrListSport { get; set; }
        public List<int> ListSportId { get; set; }
        public int SpecsId { get; set; }
        public string StrListSpecs { get; set; }
        public string StrColorID { get; set; }
        public List<int> ListSpecsId { get; set; }
        public List<int> ListColorId { get; set; }
        /// <summary>
        /// List size name
        /// </summary>
        public List<string> ListSpecs { get; set; }
        public List<int> ListProductType { get; set; }
        public string StrListCategory { get; set; }
        public string StrOriginCountry { get; set; }
        public List<int> ListCategoryId { get; set; }
        public List<string> ListManuNameOfCountries { get; set; }

        /// <summary>
        /// dùng cho trang đệm bluesport
        /// </summary>
        public bool IsBuffePage { get; set; }

        /// <summary>
        /// dùng cho trang search
        /// </summary>
        public string KeyWord { get; set; }

        //public QueryParam()
        //{
        //    PriceRange = new PriceRange();
        //    OrderTypeValue = new List<string>();
        //    ListPropDetailFilters = new List<PropertyDetailFilters>();
        //}

        public bool IsRunlive { get; set; }
        public bool IsNotGetProduct { get; set; }
        public List<int> WebIdsStatusOverride { get; set; }
        public bool IsMobileApp { get; set; }
        //public ProductCategoryDTO ProductCategoryDTO { get; set; }
    }

}
