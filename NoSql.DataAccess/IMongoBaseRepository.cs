using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using NoSql.Core.Contracts;
using NoSql.Core.Domain;

namespace NoSql.DataAccess
{
    public interface IMongoBaseRepository<TDocument> where TDocument : IBaseDocument
    {
        /// <summary>
        /// Allows access to whole non-materialised collection and perform operations later.
        /// <remarks>This is slower than other access methods because of an additional abstraction layer</remarks>
        /// </summary>
        /// <returns></returns>
        IQueryable<TDocument> AsQueryable();

        /// <summary>
        /// Filter data using expressions. Like LINQ Does
        /// </summary>
        /// <param name="filterExpression">Query Expression (Like LINQ) to execute</param>
        /// <returns></returns>
        IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Fileter data using expressions asynchronously.
        /// </summary>
        /// <param name="filterExpression"></param>
        /// <returns></returns>
        Task<IEnumerable<TDocument>> FilterByAsync(
            Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Overload that allows a projectiong to only select specific fields rather than full objects.
        /// </summary>
        /// <remarks>Executes the filter on the database, and so it is performant</remarks>
        /// <param name="filterExpression">Query Expression (Like LINQ) to execute</param>
        /// <param name="projectionExpression">Collection of fields to select.</param>
        IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);

        /// <summary>
        /// Overload that allows a projectiong to only select specific fields rather than full objects asynchronously.
        /// </summary>
        /// <remarks>Executes the filter on the database, and so it is performant</remarks>
        /// <param name="filterExpression">Query Expression (Like LINQ) to execute</param>
        /// <param name="projectionExpression">Collection of fields to select.</param>
        Task<IEnumerable<TProjected>> FilterByAsync<TProjected>(Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);

        /// <summary>
        /// Retrieve a single object, that meets expression.
        /// </summary>
        /// <param name="filterExpression">Query expression for object lookup</param>
        /// <returns></returns>
        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Retrieve a single object, that meets expression asynchronously.
        /// </summary>
        /// <param name="filterExpression">Query expression for object lookup</param>
        /// <returns></returns>
        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Retrieve a single object by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TDocument FindById(string id);

        /// <summary>
        /// Retrieve a single object by its id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TDocument> FindByIdAsync(string id);

        /// <summary>
        /// Insert a single <see cref="IBaseDocument"/>.
        /// </summary>
        /// <param name="document"></param>
        void InsertOne(TDocument document);

        /// <summary>
        /// Insert a single <see cref="IBaseDocument"/> asynchronously.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        Task InsertOneAsync(TDocument document);

        /// <summary>
        /// Insert many <see cref="IBaseDocument"/>.
        /// </summary>
        /// <param name="documents"></param>
        void InsertMany(ICollection<TDocument> documents);

        /// <summary>
        /// Insert Many <see cref="IBaseDocument"/> asynchronously.
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        Task InsertManyAsync(ICollection<TDocument> documents);

        /// <summary>
        /// Update a <see cref="IBaseDocument"/>.
        /// </summary>
        /// <param name="document"></param>
        void Update(TDocument document);

        /// <summary>
        /// Update a <see cref="IBaseDocument"/> asynchronously.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        Task UpdateAsync(TDocument document);

        /// <summary>
        /// Delete a single <see cref="IBaseDocument"/> that matches the <see cref="filterExpression"/>.
        /// </summary>
        /// <param name="filterExpression"></param>
        void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Delete a single <see cref="IBaseDocument"/> that matches the <see cref="filterExpression"/> asynchronously.
        /// </summary>
        /// <param name="filterExpression"></param>
        /// <returns></returns>
        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Delete an <see cref="IBaseDocument"/> by its Id.
        /// </summary>
        /// <param name="id">Id to delete</param>
        void DeleteById(string id);

        /// <summary>
        /// Delete an <see cref="IBaseDocument"/> by its Id asynchronously.
        /// </summary>
        /// <param name="id">Id to delete</param>
        /// <returns></returns>
        Task DeleteByIdAsync(string id);

        /// <summary>
        /// Delete all <see cref="IBaseDocument"/> that match the filterExpression.
        /// </summary>
        /// <param name="filterExpression">Where expression for filtering documents</param>
        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);

        /// <summary>
        /// Delete all <see cref="IBaseDocument"/> that math the filterExpression asynchronously.
        /// </summary>
        /// <param name="filterExpression">Where expression for filtering documents.</param>
        /// <returns></returns>
        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}