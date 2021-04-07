using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _5951071018_DOHOANGGIA_CRUD_Angular.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}