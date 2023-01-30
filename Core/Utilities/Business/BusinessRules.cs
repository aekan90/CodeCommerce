using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] isKuraliMetodları)
        {
            foreach (var isKuraliMetodu in isKuraliMetodları)
            {
                if (!isKuraliMetodu.Status)
                {
                    return isKuraliMetodu; // bütün kuralları gez uymayan varsa o kuralı döndür.
                }
            }
            return null;
        }

        // Hataları liste olarak döndürebiliriz.Farklı bir yöntem olarak.
        //public static List<IResult> Run(params IResult[] isKuraliMetodları)
        //{
        //    List<IResult> errorResult = new List<IResult>();
        //    foreach (var isKuraliMetodu in isKuraliMetodları)
        //    {
        //        if (!isKuraliMetodu.Status)
        //        {
        //            errorResult.Add(isKuraliMetodu);
        //        }
        //    }
        //    return errorResult;
        //}

    }
}
