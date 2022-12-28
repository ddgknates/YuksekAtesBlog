using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.Business.Types;
using YuksekAtesBlog.Data.Dto;
using YuksekAtesBlog.Data.Entities;
using YuksekAtesBlog.Data.Repositories;

namespace YuksekAtesBlog.Business.Managers
{
    public class PostManager : IPostService
    {
        private readonly IRepository<PostEntity> _postRepository;
        public PostManager(IRepository<PostEntity> postRepository)
        {
            _postRepository = postRepository;
        }
        public ServiceMessage AddPost(PostDto post)
        {
            var hasPost = _postRepository.GetAll(x => x.Name.ToLower().Trim() == post.Name.ToLower().Trim()).ToList();

            if (hasPost.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu İsimde Bir Ürün Mevcut."
                };
            }

            var postEntity = new PostEntity
            {
                Id = post.Id,
                Name = post.Name,
                Description = post.Description,
                Summary = post.Summary,
                ImagePath = post.ImagePath,
                CategoryId = post.CategoryId,
            };

            _postRepository.Add(postEntity);
            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeletePost(int id)
        {
            _postRepository.Delete(id);
        }

        public void EditPost(PostDto post)
        {
            var postEntity = _postRepository.GetById(post.Id);

            postEntity.Name = post.Name;
            postEntity.Description = post.Description;
            postEntity.Summary = post.Summary;
            postEntity.CategoryId = post.CategoryId;

            if (post.ImagePath != null)
            {
                postEntity.ImagePath = post.ImagePath;
            }
            postEntity.ImagePath = post.ImagePath;


            _postRepository.Update(postEntity);
        }

        public List<PostDto> GetAll(int? categoryId = null)
        {
            var query = _postRepository.GetAll();
            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            var postEntities = query.OrderBy(x => x.Category.Name).ThenBy(x => x.Name);

            var postList = postEntities.Select(x => new PostDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Summary = x.Summary,
                ImagePath = x.ImagePath,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            }).ToList();

            return postList;
        }

        public PostDto GetPostById(int id)
        {
            var postEntity = _postRepository.GetById(id);

            var postDto = new PostDto
            {
                Id = postEntity.Id,
                Name = postEntity.Name,
                Description = postEntity.Description,
                Summary= postEntity.Summary,
                ImagePath = postEntity.ImagePath,
                CategoryId = postEntity.CategoryId,

            };
            return postDto;
        }

    }
}
