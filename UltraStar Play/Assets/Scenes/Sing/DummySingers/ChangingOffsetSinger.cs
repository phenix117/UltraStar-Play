﻿public class ChangingOffsetSinger : AbstractDummySinger
{
    public int maxOffset = 5;
    private int noteOffset;
    private Note lastNote;

    protected override PitchEvent GetDummyPitchEvent(int beat, Note noteAtBeat)
    {
        // Change noteOffset when note changes.
        if (lastNote != null && noteAtBeat != lastNote)
        {
            noteOffset = noteOffset + 1;
            if (noteOffset > maxOffset)
            {
                noteOffset = 0;
            }
        }

        PitchEvent pitchEvent = null;
        if (noteAtBeat != null)
        {
            int dummyMidiNote = noteAtBeat.MidiNote + noteOffset;
            int dummyMidiNoteInSingableNoteRange = (dummyMidiNote % 12) + (5 * 12);
            pitchEvent = new PitchEvent(dummyMidiNoteInSingableNoteRange);
        }

        lastNote = noteAtBeat;
        return pitchEvent;
    }
}
