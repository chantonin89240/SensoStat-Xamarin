using System;
using System.Collections.Generic;
using SensoStat.Mobile.Models.Entities;

namespace SensoStat.Mobile.Services.Interfaces
{
    public interface IDatabaseService
    {
        SessionEntity InsertSession(SessionEntity Session);

        SessionEntity GetSessionById(int id);

        void DeleteSession(SessionEntity Session);

        List<SessionEntity> GetSessions();


        #region Instruction
        InstructionEntity InsertInstruction(InstructionEntity instruction);

        InstructionEntity GetInstructionById(int id);

        List<InstructionEntity> GetInstructions();

        #endregion

        #region Response

        ResponseEntity InsertResponse(ResponseEntity response);

        ResponseEntity GetResponsetnById(int id);

        void DeleteResponse(ResponseEntity response);

        List<ResponseEntity> GetResponses();

        #endregion

        #region Presentation

        PresentationEntity InsertPresentation(PresentationEntity presentation);

        PresentationEntity GetPresentationById(int id);

        void DeletePresentation(PresentationEntity presentation);

        List<PresentationEntity> GetPresentations();
        #endregion
    }
}