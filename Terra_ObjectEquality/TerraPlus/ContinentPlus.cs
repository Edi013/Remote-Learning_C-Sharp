using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using iQuest.Terra;

namespace iQuest.TerraPlus
{
    public class ContinentPlus
    {
        private List<Country> countries = new List<Country>();

        public ContinentPlus()
        {
        }

        public ContinentPlus(IEnumerable<Country> countries)
        {
            if (countries == null) throw new ArgumentNullException(nameof(countries));

            this.countries.AddRange(countries);
        }

        public IEnumerable<Country> EnumerateCountriesByName()
        {
            countries.Sort();
            return countries;
        }

        public IEnumerable<Country> EnumerateCountriesByCapital()
        {
            SortByCapital();

            return countries;
        }
        public void SortByCapital()
        {
            var implementationType = ConfigurationManager.AppSettings["ImplementationType"];

            if (implementationType == null)
                implementationType = "2";

            switch (implementationType)
            {
                case "1":
                    this.countries = countries.OrderBy(x => x.Capital).ToList();
                    break;

                case "2":
                    CustomSortingMethod();
                    break;
            }
        }
        public void CustomSortingMethod()
        {
            for(int contorOfCountries1 = 0; contorOfCountries1 < this.countries.Count - 1; contorOfCountries1++)
            {
                if (countries[contorOfCountries1] == null)
                {
                    if(contorOfCountries1 == 0)
                        continue;

                    if(SwapIfNull(contorOfCountries1))
                        continue;
                }

                for (int contorOfCountries2 = contorOfCountries1 + 1; contorOfCountries2 < this.countries.Count; contorOfCountries2++)
                {
                    if (countries[contorOfCountries2] == null)
                    {
                        SwapIfNull(contorOfCountries2);
                        break;
                    }

                    var result = countries[contorOfCountries1].Capital.CompareTo(countries[contorOfCountries2].Capital);
                    switch (result)
                    {
                        case 1:
                            {
                                SwapVariables(contorOfCountries1, contorOfCountries2);
                                break;
                            }
                    }
                }
            }
        }
        private bool SwapIfNull(int indexOfCheckedVariable)
        {
                var result = FindFirstIndexOfNotNullInList();

                if (result != -1)
                {
                    SwapVariables(indexOfCheckedVariable, result);
                    return true;
                }
            
            return false;
        }
        private int FindFirstIndexOfNotNullInList()
        {
            for(int contorOfNonNullCountry = 0; contorOfNonNullCountry < this.countries.Count; contorOfNonNullCountry++)
            {
                if (countries[contorOfNonNullCountry] != null)
                {
                    return contorOfNonNullCountry;
                }
            }
            return -1;
        }
        private void SwapVariables(int index1, int index2)
        {
            var saveCountry = countries[index1];
            countries[index1] = countries[index2];
            countries[index2] = saveCountry;
        }
    }
}