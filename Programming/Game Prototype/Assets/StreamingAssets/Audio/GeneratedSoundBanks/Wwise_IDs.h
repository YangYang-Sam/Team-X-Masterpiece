/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID ALL_PLANE_AMBIENCE = 124093304U;
        static const AkUniqueID ALL_PLANE_MUSIC = 1985200777U;
        static const AkUniqueID BOULDER = 3054124956U;
        static const AkUniqueID DEAD = 2044049779U;
        static const AkUniqueID FIRE = 2678880713U;
        static const AkUniqueID GHOUL = 3922529076U;
        static const AkUniqueID GOO = 546106858U;
        static const AkUniqueID JUMPING = 68157183U;
        static const AkUniqueID LANDING = 2548270042U;
        static const AkUniqueID OGRE_CHARGE = 2456307347U;
        static const AkUniqueID OGRE_DEAD = 626833781U;
        static const AkUniqueID PLATFORM = 4035573696U;
        static const AkUniqueID PROGRESS = 308635872U;
        static const AkUniqueID ROTATE = 1302771492U;
        static const AkUniqueID TEXT = 2972449336U;
        static const AkUniqueID TEXTBLEEP = 2124608308U;
        static const AkUniqueID VEILJUMP = 1671131289U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace AMBIENCE_STATE
        {
            static const AkUniqueID GROUP = 3875263435U;

            namespace STATE
            {
                static const AkUniqueID AMBIAZTEC = 3051088207U;
                static const AkUniqueID AMBIEASTERN = 1513158036U;
                static const AkUniqueID AMBIEGYPT = 1648913497U;
            } // namespace STATE
        } // namespace AMBIENCE_STATE

        namespace FIRE_YES_NO
        {
            static const AkUniqueID GROUP = 2378512989U;

            namespace STATE
            {
                static const AkUniqueID NEAR_FIRE = 278232202U;
                static const AkUniqueID NO_FIRE = 3752417319U;
            } // namespace STATE
        } // namespace FIRE_YES_NO

        namespace GOO_YES_NO
        {
            static const AkUniqueID GROUP = 3120631408U;

            namespace STATE
            {
                static const AkUniqueID NEAR_GOO = 978856375U;
                static const AkUniqueID NO_GOO = 4147008840U;
            } // namespace STATE
        } // namespace GOO_YES_NO

        namespace MENU_OR_LEVEL
        {
            static const AkUniqueID GROUP = 1222409307U;

            namespace STATE
            {
                static const AkUniqueID LEVEL = 2782712965U;
                static const AkUniqueID MENU = 2607556080U;
            } // namespace STATE
        } // namespace MENU_OR_LEVEL

        namespace MUSIC_STATE
        {
            static const AkUniqueID GROUP = 3826569560U;

            namespace STATE
            {
                static const AkUniqueID AZTEC = 3866797368U;
                static const AkUniqueID EASTERN = 3476384675U;
                static const AkUniqueID EGYPTIAN = 3835820942U;
                static const AkUniqueID ENDLEVEL = 1054659462U;
                static const AkUniqueID MENUSTATE = 1548586727U;
            } // namespace STATE
        } // namespace MUSIC_STATE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace DOOR
        {
            static const AkUniqueID GROUP = 1877847629U;

            namespace SWITCH
            {
            } // namespace SWITCH
        } // namespace DOOR

        namespace PLANE_SELECTION
        {
            static const AkUniqueID GROUP = 1818010914U;

            namespace SWITCH
            {
                static const AkUniqueID AZTEC = 3866797368U;
                static const AkUniqueID EASTERN = 3476384675U;
                static const AkUniqueID EGYPTIAN = 3835820942U;
            } // namespace SWITCH
        } // namespace PLANE_SELECTION

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID GAME_PAUSE = 2772308904U;
        static const AkUniqueID MENU_MUSIC = 4055567060U;
        static const AkUniqueID MUSIC_SLOWDOWN = 2779281842U;
        static const AkUniqueID MUSICVOLUME = 2346531308U;
        static const AkUniqueID SFXVOLUME = 988953028U;
        static const AkUniqueID TEXTSKIP = 2396826149U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID PLATFORM = 4035573696U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID TVEIL_LVL_SB = 928849380U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MUSIC_VOLUME_BUS = 149712868U;
        static const AkUniqueID SFX_VOLUME_BUS = 2769831052U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
