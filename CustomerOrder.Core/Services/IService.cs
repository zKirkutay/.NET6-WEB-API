﻿using CustomerOrder.Core.DTOs;
using CustomerOrder.Core.Models;
using System.Linq.Expressions;

namespace CustomerOrder.Core.Services
{
    public interface IService<Entity, DTO> where Entity : BaseEntity where DTO : class
    {
        Task<CustomResponseDTO<DTO>> GetByIdAsync(int id);
        Task<CustomResponseDTO<IEnumerable<DTO>>> GetAllAsync();
        Task<CustomResponseDTO<IEnumerable<DTO>>> Where(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDTO<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDTO<DTO>> AddAsync(DTO dto);
        Task<CustomResponseDTO<IEnumerable<DTO>>> AddRangeAsync(IEnumerable<DTO> dtos);
        Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(DTO dto);
        Task<CustomResponseDTO<NoContentDTO>> RemoveAsync(int id);
        Task<CustomResponseDTO<NoContentDTO>> RemoveRangeAsync(IEnumerable<int> ids);
    }
}
