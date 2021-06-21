SELECT DISTINCT
       t.*
FROM Teacher t
    INNER JOIN Teacher_Pupil_Mapping tpm
        ON t.Id = tpm.TeacherId
    INNER JOIN Pupil p
        ON tpm.PupilId = p.Id
           AND p.FirstName = N'გიორგი'