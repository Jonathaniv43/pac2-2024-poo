using BlogUNAH.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BlogUNAH.API.Database
{
    public class BlogUNAHSeeder
    {
        public static async Task LoadDataAsync(
            //uso de datos de entity framework acceso al contexto de la base de datos
            BlogUNAHContext context,
            ILoggerFactory loggerFactory
            )
        {
            try
            {
                await LoadCategoriesasync(loggerFactory,context);
                await LoadPostasync(loggerFactory,context);
                await LoadTagsasync(loggerFactory,context);
                await LoadPostTagsasync(loggerFactory,context);
                
            }
            catch (Exception e)
            {
                // da la posibilidad de enviar datos a la consola 
                var logger = loggerFactory.CreateLogger<BlogUNAHSeeder>();
                logger.LogError(e, "Error inicializando la data de API");

            }
        }

        public static async Task LoadCategoriesasync(ILoggerFactory loggerFactory , BlogUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/categories.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var categories = JsonConvert.DeserializeObject<List<CategoryEntity>>(jsonContent);
                
                if (!await context.Categories.AnyAsync()) // Devuelve verdadero si no encuentra informacion
                    // dentro de la base de datos 
                    // Devuelve falso si existe información
                {
                    for (int i = 0; i < categories.Count; i++) { 
                    
                        categories[i].CreatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        categories[i].CreatedDate = DateTime.Now;
                        categories[i].UpdatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        categories[i].UpdatedDate = DateTime.Now;
                    }
                    // Envia objetos Add 1 Addrange  muchos
                    // marca los que le mandamos para insertarlos en la base de tos debemos guardarlos 
                    // para poder mandarlos hacemos uside save changes
                    context.AddRange(categories);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception e) 
            {
                var logger = loggerFactory.CreateLogger<BlogUNAHSeeder>();
                logger.LogError(e, "Error al ejecutar el seed de categorias");
            }

        }

        public static async Task LoadPostasync(ILoggerFactory loggerFactory, BlogUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/posts.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var post = JsonConvert.DeserializeObject<List<PostEntity>>(jsonContent);

                if (!await context.Posts.AnyAsync()) // Devuelve verdadero si no encuentra informacion
                                                          // dentro de la base de datos 
                                                          // Devuelve falso si existe información
                {
                    for (int i = 0; i < post.Count; i++)
                    {

                        post[i].CreatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        post[i].CreatedDate = DateTime.Now;
                        post[i].UpdatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        post[i].UpdatedDate = DateTime.Now;
                    }
                    // Envia objetos Add 1 Addrange  muchos
                    // marca los que le mandamos para insertarlos en la base de tos debemos guardarlos 
                    // para poder mandarlos hacemos uside save changes
                    context.AddRange(post);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<BlogUNAHSeeder>();
                logger.LogError(e, "Error al ejecutar el seed de Post");
            }


        }

        public static async Task LoadTagsasync(ILoggerFactory loggerFactory, BlogUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/tags.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var tags = JsonConvert.DeserializeObject<List<TagEntity>>(jsonContent);

                if (!await context.Tags.AnyAsync()) // Devuelve verdadero si no encuentra informacion
                                                          // dentro de la base de datos 
                                                          // Devuelve falso si existe información
                {
                    for (int i = 0; i < tags.Count; i++)
                    {

                        tags[i].CreatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        tags[i].CreatedDate = DateTime.Now;
                        tags[i].UpdatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        tags[i].UpdatedDate = DateTime.Now;
                    }
                    // Envia objetos Add 1 Addrange  muchos
                    // marca los que le mandamos para insertarlos en la base de tos debemos guardarlos 
                    // para poder mandarlos hacemos uside save changes
                    context.AddRange(tags);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<BlogUNAHSeeder>();
                logger.LogError(e, "Error al ejecutar el seed de tags");
            }

        }
        public static async Task LoadPostTagsasync(ILoggerFactory loggerFactory, BlogUNAHContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/post_tags.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var PostTags = JsonConvert.DeserializeObject<List<PostTagEntity>>(jsonContent);

                if (!await context.PostTags.AnyAsync()) // Devuelve verdadero si no encuentra informacion
                                                          // dentro de la base de datos 
                                                          // Devuelve falso si existe información
                {
                    for (int i = 0; i < PostTags.Count; i++)
                    {

                        PostTags[i].CreatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        PostTags[i].CreatedDate = DateTime.Now;
                        PostTags[i].UpdatedBy = "bb117f8f-93ef-45a3-8e75-f428f75ac5c0";
                        PostTags[i].UpdatedDate = DateTime.Now;
                    }
                    // Envia objetos Add 1 Addrange  muchos
                    // marca los que le mandamos para insertarlos en la base de tos debemos guardarlos 
                    // para poder mandarlos hacemos uside save changes
                    context.AddRange(PostTags);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<BlogUNAHSeeder>();
                logger.LogError(e, "Error al ejecutar el seed de Post Tags");
            }

        }
    }
}
    

    



    
    



