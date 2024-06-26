﻿using Core.Domain.Entities;
using Core.Domain.Services;

namespace Infrastructure;

public class JudgeTestRepository : IJudgeRepository
{
    public List<Judge> TestJudges { get; } = new List<Judge>();

    public async Task AddJudge(Judge judge)
    {
        judge.JudgeId = TestJudges.Count + 1;
        TestJudges.Add(judge);
        await Task.CompletedTask;
    }


    public async Task<Judge?> GetJudge(int judgeId)
    {
        Judge? judge = TestJudges.SingleOrDefault(j => j.JudgeId == judgeId);
        return await Task.FromResult(judge);
    }


    public async Task<IEnumerable<Judge>> GetAllJudges()
    {
        return await Task.FromResult(TestJudges);
    }


    public async Task UpdateJudge(Judge updatedJudge)
    {
        Judge? judgeToUpdate = TestJudges
            .SingleOrDefault(j => j.JudgeId == updatedJudge.JudgeId);

        if (judgeToUpdate != null)
        {
            judgeToUpdate.FirstName = updatedJudge.FirstName;
            judgeToUpdate.LastName = updatedJudge.LastName;
        }
        await Task.CompletedTask;
    }


    public async Task DeleteJudge(int judgeId)
    {
        Judge? judgeToDelete = TestJudges.SingleOrDefault(j => j.JudgeId == judgeId);

        if (judgeToDelete != null)
        {
            TestJudges.Remove(judgeToDelete);
        }
        await Task.CompletedTask;
    }

    public Task GetJudgesFromFirstName(string firstName)
    {
        throw new NotImplementedException();
    }

    Task<List<Judge>> IJudgeRepository.GetJudgesFromFirstName(string firstName)
    {
        throw new NotImplementedException();
    }

    public Task<List<Judge>> GetJudgesFromLastName(string lastName)
    {
        throw new NotImplementedException();
    }
}
