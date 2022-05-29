// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="The Virtual Forge">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <summary>
// 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using Dapper;
using Demo.Domain;
using Demo.Domain.Repository;
using SqlKata;
using SqlKata.Compilers;

namespace Demo.DapperSqlKata.Repositories
{
    public class Repository<T, Key> : IRepository<T, Key> where T : Domain<Key> where Key : struct
    {
        /// <summary>
        /// Gets or sets the query timeout.
        /// </summary>
        public int QueryTimeout { get; set; } = 30;

        /// <summary>
        /// Gets the connection.
        /// </summary>
        protected IDbConnection Connection { get; private set; }

        /// <summary>
        /// Gets or sets the compiler.
        /// </summary>
        protected Compiler Compiler { get; set; }


        public Repository(ApplicationConnection applicationConnection)
        {
            this.Connection = applicationConnection.GetConnection();
            this.Compiler = applicationConnection.Compiler;
        }

        public T GetById(Key id)
        {
            var query = new Query(typeof(T).Name);
            query = query.Where("Id", id);

            return this.Connection.QuerySingleOrDefault<T>(this.GetCommandDefinitionByQuery(query));
        }

        public IEnumerable<T> GetAll()
        {
            var query = new Query(typeof(T).Name);

            return this.Connection.Query<T>(this.GetCommandDefinitionByQuery(query));
        }

        public void Add(T entity)
        {
            var query = new Query(typeof(T).Name).AsInsert(entity);

            this.Connection.Execute(this.GetCommandDefinitionByQuery(query));
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                var query = new Query(typeof(T).Name).AsInsert(entity);

                this.Connection.Execute(this.GetCommandDefinitionByQuery(query));
            }
        }

        public void Remove(T entity)
        {
            var query = new Query(typeof(T).Name).AsDelete().Where("Id", entity.Id);

            this.Connection.Execute(this.GetCommandDefinitionByQuery(query));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            var query = new Query(typeof(T).Name).AsDelete().WhereIn("Id", entities.Select(e => e.Id));

            this.Connection.Execute(this.GetCommandDefinitionByQuery(query));
        }


        internal CommandDefinition GetCommandDefinitionByQuery(Query query, CommandFlags flags = CommandFlags.Buffered)
        {
            var compiled = this.CompileAndLog(query);

            return new CommandDefinition(
                commandText: compiled.Sql.Replace("URLQUERY", "?"),
                parameters: compiled.NamedBindings,
                cancellationToken: default,
                flags: flags
            );
        }

        internal SqlResult CompileAndLog(Query query)
        {
            var compiled = this.Compiler.Compile(query);

            return compiled;
        }
    }
}