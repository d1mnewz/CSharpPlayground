using System;
using System.Reflection;

namespace _13_LosingHttpContextConfigureAwaitVanilla.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}