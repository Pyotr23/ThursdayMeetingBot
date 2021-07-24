using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ThursdayMeetingBot.Libraries.Data.Helpers
{
    public class CaseSetter
    {
        private readonly Func<string, string> _getNewName;
        private readonly ModelBuilder _modelBuilder;
        private IMutableEntityType _entityType;

        public CaseSetter(Func<string, string> nameChangeRule, ModelBuilder modelBuilder)
        {
            _getNewName = nameChangeRule;
            _modelBuilder = modelBuilder;
        }
        
        public void ChangeDatabaseEntityNames()
        {
            foreach (var entityType in _modelBuilder.Model.GetEntityTypes())
            {
                _entityType = entityType;
                ChangeTableName();
                ChangeColumnNames();
                ChangeKeyNames();
                ChangeForeignKeyNames();
                ChangeIndexNames();
            }
        }

        private void ChangeTableName()
        {
            var newName = _getNewName(_entityType.GetTableName());
            _entityType.SetTableName(newName);
        }

        private void ChangeColumnNames()
        {
            foreach (var property in _entityType.GetProperties())
            {
                var newName = _getNewName(property.Name);
                property.SetColumnName(newName);
            }
        }

        private void ChangeKeyNames()
        {
            foreach (var key in _entityType.GetKeys())
            {
                var newName = _getNewName(key.GetName());
                key.SetName(newName);
            }
        }

        private void ChangeForeignKeyNames()
        {
            foreach (var key in _entityType.GetForeignKeys())
            {
                var oldName = key.PrincipalKey.GetName();
                var newName = _getNewName(oldName);
                key.PrincipalKey.SetName(newName);
            }
        }

        private void ChangeIndexNames()
        {
            foreach (var index in _entityType.GetIndexes())
            {
                var newName = _getNewName(index.GetDatabaseName());
                index.SetDatabaseName(newName);
            }
        }
    }
}