using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace BlogManagement.Configuration.Permissions
{
    public class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<List<string>, List<PermissionDto>> Expose()
        {
            return new Dictionary<List<string>, List<PermissionDto>>
            {
                {
                    new List<string>()
                   {
                       "ArticleCategorie",
                       "گروه مقالات"
                   },
                   new List<PermissionDto>
                    {
                        new PermissionDto(BlogPermissions.ListArticleCategories ,  "ListArticleCategories","لیست گروه مقالات"),
                        new PermissionDto(BlogPermissions.SearchArticleCategories, "SearchArticleCategories","جستجوی گروه مقالات"),
                        new PermissionDto(BlogPermissions.CreateArticleCategorie, "CreateArticleCategorie","گروه مقاله جدید"),
                        new PermissionDto(BlogPermissions.EditArticleCategorie, "EditArticleCategorie","ویرایش گروه مقاله"),
                    }
                },
                {
                    new List<string>()
                    {
                        "Article",
                        "مقالات"
                    },
                    new List<PermissionDto>
                    {
                        new PermissionDto(BlogPermissions.ListArticles, "ListArticles","لیست مقالات"),
                        new PermissionDto(BlogPermissions.SearchArticles, "SearchArticles","جستجوی مقالات"),
                        new PermissionDto(BlogPermissions.CreateArticle, "CreateArticle","ایجاد مقاله جدید"),
                        new PermissionDto(BlogPermissions.EditArticle, "EditArticle","ویرایش مقاله"),
                        
                    }
                }
            };
        }
    }
}