from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI(title="Job Skill Matcher")

SKILLS = [
    "c#", ".net", "asp.net", "angular", "javascript", "python", "sql",
    "sql server", "mysql", "aws", "s3", "lambda", "docker", "git",
    "rest api", "entity framework", "tableau", "spark", "machine learning"
]

class MatchRequest(BaseModel):
    job_description: str
    candidate_skills: list[str]

@app.get("/health")
def health():
    return {"status": "ok"}

@app.post("/match")
def match_skills(body: MatchRequest):
    description = body.job_description.lower()
    required = sorted({skill for skill in SKILLS if skill in description})
    candidate = {skill.lower().strip() for skill in body.candidate_skills}
    matched = [skill for skill in required if skill in candidate]
    missing = [skill for skill in required if skill not in candidate]
    score = round((len(matched) / len(required) * 100), 1) if required else 0.0
    return {
        "required_skills": required,
        "matched_skills": matched,
        "missing_skills": missing,
        "match_percentage": score
    }
