using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
namespace CloudChatService.API.ProgramFactory
{
    //public class CustomJsonConverterForType : JsonConverter<Type>
    //{
    //    public override Type Read(
    //        ref Utf8JsonReader reader,
    //        Type typeToConvert,
    //        JsonSerializerOptions options
    //        )
    //    {
    //        // Caution: Deserialization of type instances like this 
    //        // is not recommended and should be avoided
    //        // since it can lead to potential security issues.

    //        // If you really want this supported (for instance if the JSON input is trusted):
    //        // string assemblyQualifiedName = reader.GetString();
    //        // return Type.GetType(assemblyQualifiedName);
    //        throw new NotSupportedException();
    //    }

    //    public override void Write(
    //        Utf8JsonWriter writer,
    //        Type value,
    //        JsonSerializerOptions options
    //        )
    //    {
    //        string assemblyQualifiedName = value.AssemblyQualifiedName;
    //        // Use this with caution, since you are disclosing type information.
    //        writer.WriteStringValue(assemblyQualifiedName);
    //    }
    //}
    public static class CustomJson
    {
        public static IServiceCollection AddCustomJson(this IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });
    //        services
    //.AddControllers(options =>
    //{
    //    options.EnableEndpointRouting = false;
    //})
    //.AddNewtonsoftJson()
    //.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
    //.AddJsonOptions(options =>
    //{
    //    options.JsonSerializerOptions.IgnoreNullValues = true;
    //    options.JsonSerializerOptions.WriteIndented = true;
    //});
            return services;
        }
    }
}
