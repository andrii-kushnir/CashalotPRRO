using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class Objects : RequestBase
    {
        public string Command { get; set; } = "Objects";
    }

    public class ObjectsResult : ErrorBase
    {
        public Taxobject[] TaxObjects { get; set; }
    }
    public class Taxobject
    {
        public int Entity { get; set; } // Ідентифікатор ГО
        public string TaxObjGuid { get; set; } // Ідентифікатор запису ОО
        public int TaxObjId { get; set; } // Код запису ОО
        public bool SingleTax { get; set; } // Ознака ФОП - платника єдиного податку
        public string Name { get; set; } // Найменування ГО
        public string Address { get; set; } // Адреса ГО
        public string Tin { get; set; } // Код ЄДРПОУ/ДРФО платника податків
        public object Ipn { get; set; } // Податковий номер платника ПДВ
        public string OrgName { get; set; } // Найменування суб’єкта господарювання
        public bool ChiefCashier { get; set; } // Старший касир
        public Transactionsregistrar[] TransactionsRegistrars { get; set; }
    }
    public class Transactionsregistrar
    {
        public long NumFiscal { get; set; } // Фіскальний номер ПРРО
        public int NumLocal { get; set; } // Локальний номер ПРРО
        public string Name { get; set; } // Найменування ПРРО
        public bool Closed { get; set; } // Ознака скасованої реєстрації ПРРО, на якому наразі не закрито зміну
    }
}




