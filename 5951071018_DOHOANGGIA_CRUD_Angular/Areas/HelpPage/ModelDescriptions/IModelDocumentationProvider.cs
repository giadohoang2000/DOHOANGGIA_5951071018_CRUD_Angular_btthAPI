using System;
using System.Reflection;

namespace _5951071018_DOHOANGGIA_CRUD_Angular.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}