using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Services
{
    public abstract class BaseCrudService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly PersonalAccountDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseCrudService(PersonalAccountDbContext context, IMapper mapper, ILogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            _logger.LogInformation("Получение всех записей для {Entity}", typeof(TEntity).Name);
            var list = _dbSet.ToList();
            _logger.LogInformation("Найдено записей: {Count}", list.Count);
            return _mapper.Map<IEnumerable<TDto>>(list);
        }

        public virtual TDto? GetById(int id)
        {
            _logger.LogInformation("Получение {Entity} с Id={Id}", typeof(TEntity).Name, id);
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                _logger.LogWarning("{Entity} с Id={Id} не найден", typeof(TEntity).Name, id);
                return null;
            }

            return _mapper.Map<TDto>(entity);
        }

        public virtual TDto Create(TDto dto)
        {
            _logger.LogInformation("Создание новой записи {Entity}", typeof(TEntity).Name);
            var entity = _mapper.Map<TEntity>(dto);
            _dbSet.Add(entity);
            _context.SaveChanges();
            _logger.LogInformation("{Entity} создан с Id", typeof(TEntity).Name);
            return _mapper.Map<TDto>(entity);
        }

        public virtual TDto? Update(int id, TDto dto)
        {
            _logger.LogInformation("Обновление {Entity} с Id={Id}", typeof(TEntity).Name, id);
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                _logger.LogWarning("{Entity} с Id={Id} не найден для обновления", typeof(TEntity).Name, id);
                return null;
            }

            _mapper.Map(dto, entity);
            _context.SaveChanges();
            _logger.LogInformation("{Entity} с Id={Id} успешно обновлён", typeof(TEntity).Name, id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual bool Delete(int id)
        {
            _logger.LogInformation("Удаление {Entity} с Id={Id}", typeof(TEntity).Name, id);
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                _logger.LogWarning("{Entity} с Id={Id} не найден для удаления", typeof(TEntity).Name, id);
                return false;
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
            _logger.LogInformation("{Entity} с Id={Id} успешно удалён", typeof(TEntity).Name, id);
            return true;
        }
    }
}
