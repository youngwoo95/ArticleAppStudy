using Dul.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ArticleStudy.Models.Database
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleAppDbContext _context;

        public ArticleRepository(ArticleAppDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Article> AddArticleAsync(Article model)
        {
            _context.Articles.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        /// <summary>
        /// 출력
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _context.Articles.OrderByDescending(m => m.id).ToListAsync();
        }

        /// <summary>
        /// 상세보기
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Article> EditArticleAsync(Article model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return model;
        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteArticleAsync(int id)
        {
            var model = await _context.Articles.Where(m => m.id == id).SingleOrDefaultAsync();
            if(model != null)
            {
                _context.Articles.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 페이징
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PagingResult<Article>> GetAllAsync(int pageIndex, int pageSize)
        {
            var totalRecord = await _context.Articles.CountAsync();
            var model = await _context.Articles
                        .OrderByDescending(m => m.id)
                        .Skip(pageIndex * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return new PagingResult<Article>(model, totalRecord);
        }

        

       
    }
}
