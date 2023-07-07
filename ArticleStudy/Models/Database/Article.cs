using Dul.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleStudy.Models.Database
{
    [Table("Articles")]
    public class Article
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        [Required(ErrorMessage = "제목을 입력해주세요.")]
        public string Title { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        [Required(ErrorMessage = "내용을 입력해주세요.")]
        public string Content { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; }

        public DateTime Modified { get; set; } = DateTime.Now;

        /// <summary>
        /// 공지글로 올리기
        /// </summary>
        public bool IsPinned { get; set; } = false;
    }
}
