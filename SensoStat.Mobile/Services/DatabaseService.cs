using System;
using System.Collections.Generic;
using SensoStat.Mobile.Models.Entities;
using SensoStat.Mobile.Repositories.Interface;
using SensoStat.Mobile.Services.Interfaces;

namespace SensoStat.Mobile.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IRepository<SessionEntity> _sessionRepository;
        private readonly IRepository<InstructionEntity> _instructionRepository;
        private readonly IRepository<ResponseEntity> _responseRepository;
        private readonly IRepository<PresentationEntity> _presentationRepository;

        public DatabaseService(IRepository<SessionEntity> sessionRepository, IRepository<InstructionEntity> instructionRepository,
            IRepository<ResponseEntity> responseRepository, IRepository<PresentationEntity> presentationRepository)
        {
            _sessionRepository = sessionRepository;
            _instructionRepository = instructionRepository;
            _responseRepository = responseRepository;
            _presentationRepository = presentationRepository;
        }

        #region Session

        public SessionEntity InsertSession(SessionEntity session)
        {
            try
            {
                return _sessionRepository.Insert(session);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public SessionEntity GetSessionById(int id)
        {
            try
            {
                return _sessionRepository.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void DeleteSession(SessionEntity session)
        {
            try
            {
                _sessionRepository.Delete(session);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<SessionEntity> GetSessions()
        {
            try
            {
                return _sessionRepository.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion

        #region Instruction

        public InstructionEntity InsertInstruction(InstructionEntity instruction)
        {
            try
            {
                return _instructionRepository.Insert(instruction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public InstructionEntity GetInstructionById(int id)
        {
            try
            {
                return _instructionRepository.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<InstructionEntity> GetInstructions()
        {
            try
            {
                return _instructionRepository.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion

        #region Response

        public ResponseEntity InsertResponse(ResponseEntity response)
        {
            try
            {
                return _responseRepository.Insert(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ResponseEntity GetResponsetnById(int id)
        {
            try
            {
                return _responseRepository.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void DeleteResponse(ResponseEntity response)
        {
            try
            {
                _responseRepository.Delete(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<ResponseEntity> GetResponses()
        {
            try
            {
                return _responseRepository.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion

        #region Presentation

        public PresentationEntity InsertPresentation(PresentationEntity presentation)
        {
            try
            {
                return _presentationRepository.Insert(presentation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public PresentationEntity GetPresentationById(int id)
        {
            try
            {
                return _presentationRepository.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void DeletePresentation(PresentationEntity presentation)
        {
            try
            {
                _presentationRepository.Delete(presentation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<PresentationEntity> GetPresentations()
        {
            try
            {
                return _presentationRepository.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion
    }
}
